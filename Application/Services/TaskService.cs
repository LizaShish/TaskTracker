using Application.Interfaces;
using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.Services;

public class TaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository ;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDTO>> GetAll()
    {
        var tasks = await _taskRepository.GetAll();
        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }

    public async Task<TaskDTO?> GetById(Guid id)
    {
        var task = await _taskRepository.GetById(id);
        if (task == null)
        {
            throw new KeyNotFoundException($"Задача с id '{id}' не найдена.");
        }
        return _mapper.Map<TaskDTO>(task);
    }

    public async Task Create(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskEntity>(taskDTO);
        task.CreateDate = DateTime.UtcNow;
        task.UpdateDate = DateTime.UtcNow;
        var createTask = await _taskRepository.Create(task);
    }

    public async Task Update(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskEntity>(taskDTO);
        task.UpdateDate = DateTime.UtcNow;
        
         await _taskRepository.Update(task);
    }

    public async Task Delete(Guid id)
    {
        await _taskRepository.Delete(id);
    }
    public async Task<IEnumerable<TaskDTO>> Filter(string status, string assignedTo)
    {
        var tasks = await _taskRepository.Filter(status, assignedTo);
        if (!string.IsNullOrWhiteSpace(status))
            tasks = tasks.Where(x => x.Status == status);
        if (!string.IsNullOrWhiteSpace(assignedTo))
            tasks = tasks.Where(x => x.AssignedTo == assignedTo);
        
        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }
}