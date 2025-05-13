using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController:ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskDTO taskDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _taskService.CreateAsync(taskDto);
        return Ok("Task created");
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TaskDTO taskDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _taskService.UpdateAsync(taskDto);
        return Ok("Task updated");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskService.DeleteAsync(id);
        return Ok("Task deleted");
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] string status, string assignedTo)
    {
        var tasks = await _taskService.FilterAsync(status, assignedTo);
        return Ok(tasks);
    }
    
}