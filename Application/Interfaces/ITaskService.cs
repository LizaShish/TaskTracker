using Application.DTOs;

namespace Application.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDTO>> GetAllAsync();
    Task<TaskDTO> GetByIdAsync(int id);
    Task  CreateAsync(TaskDTO taskDTO);
    Task  UpdateAsync(TaskDTO taskDTO);
    Task DeleteAsync(int id);
    Task<IEnumerable<TaskDTO>> FilterAsync(string status, string assignedTo);
}