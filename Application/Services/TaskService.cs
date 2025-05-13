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

    public async Task<IEnumerable<TaskDTO>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }

    public async Task<TaskDTO?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return task == null? null: _mapper.Map<TaskDTO>(task);
    }

    public async Task CreateAsync(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskEntity>(taskDTO);
        task.CreateDate = DateTime.UtcNow;
        task.UpdateDate = DateTime.UtcNow;
        var createTask = await _taskRepository.CreateAsync(task);
    }

    public async Task UpdateAsync(TaskDTO taskDTO)
    {
        var task = _mapper.Map<TaskEntity>(taskDTO);
        task.UpdateDate = DateTime.UtcNow;
        
         await _taskRepository.UpdateAsync(task);
    }

    public async Task DeleteAsync(int id)
    {
        await _taskRepository.DeleteAsync(id);
    }
    public async Task<IEnumerable<TaskDTO>> FilterAsync(string status, string assignedTo)
    {
        var tasks = await _taskRepository.FilterAsync(status, assignedTo);
        if (!string.IsNullOrWhiteSpace(status))
            tasks = tasks.Where(x => x.Status == status);
        if (!string.IsNullOrWhiteSpace(assignedTo))
            tasks = tasks.Where(x => x.AssignedTo == assignedTo);
        return tasks.Select(x => new TaskDTO
        {
            TaskId = x.TaskId,
            Title = x.Title,

        });
        //return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
    }
}