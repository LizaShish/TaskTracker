using Core.Entities;

namespace Application.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAll();
    Task<TaskEntity> GetById(Guid id);
    Task<TaskEntity> Create(TaskEntity task);
    Task<TaskEntity> Update(TaskEntity task);
    Task Delete(Guid id);
    Task<IEnumerable<TaskEntity>> Filter(string status, string assignedTo);
    
}