using Core.Entities;

namespace Application.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAllAsync();
    Task<TaskEntity> GetByIdAsync(int id);
    Task<TaskEntity> CreateAsync(TaskEntity task);
    Task<TaskEntity> UpdateAsync(TaskEntity task);
    Task DeleteAsync(int id);
    Task<IEnumerable<TaskEntity>> FilterAsync(string status, string assignedTo);
    
}