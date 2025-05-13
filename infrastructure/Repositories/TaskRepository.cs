using Application.Interfaces;
using infrastructure.Data;
using Core.Entities;
    using Microsoft.EntityFrameworkCore;
    

namespace infrastructure.Repositories;

public class TaskRepository:ITaskRepository
{
    private readonly AppDbContext _appDbContext;

    public TaskRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllAsync() =>
        await _appDbContext.Tasks.ToListAsync();

    public async Task<TaskEntity> GetByIdAsync(int id)
    {
        return await _appDbContext.Tasks.FindAsync(id);
    }

    public async Task<TaskEntity> CreateAsync(TaskEntity task)
    {
        
        var addTask = new TaskEntity
        {
            Title = task.Title,
            Description = task.Description,
            Status = task.Status,
            AssignedTo = task.AssignedTo,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow,
        };
        await _appDbContext.Tasks.AddAsync(task);
        await _appDbContext.SaveChangesAsync();
        return addTask;
    }

    public async Task<TaskEntity> UpdateAsync(TaskEntity task)
    {
        var updateTask = await _appDbContext.Tasks.FindAsync(task.TaskId);
        if (updateTask != null)
        {
            updateTask.Title = task.Title;
            updateTask.Description = task.Description;
            updateTask.Status = task.Status;
            updateTask.AssignedTo = task.AssignedTo;
            updateTask.UpdateDate = DateTime.UtcNow;
            await _appDbContext.SaveChangesAsync();
        }
        return updateTask;
    }

    public async Task DeleteAsync(int id)
    {
        var deleteTask = await _appDbContext.Tasks.FindAsync(id);
        if (deleteTask != null)
        {
            _appDbContext.Tasks.Remove(deleteTask);
            await _appDbContext.SaveChangesAsync();
        }
        
    }
    
    public async Task<IEnumerable<TaskEntity>> FilterAsync(string status, string assignedTo)
    {
        return await _appDbContext.Tasks
            .Where(x => x.Status == status && x.AssignedTo == assignedTo).ToListAsync();
    }
}