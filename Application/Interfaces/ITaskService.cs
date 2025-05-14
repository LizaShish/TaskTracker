using Application.DTOs;

namespace Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDTO>> GetAll();
    Task<TaskDTO> GetById(Guid id);
    Task  Create(TaskDTO taskDTO);
    Task  Update(TaskDTO taskDTO);
    Task Delete(Guid id);
    Task<IEnumerable<TaskDTO>> Filter(string status, string assignedTo);
}