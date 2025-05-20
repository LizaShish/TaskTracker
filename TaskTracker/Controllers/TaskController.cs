using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAll();
        return Ok(tasks);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var task = await _taskService.GetById(id);
            return Ok(task);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskDTO taskDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _taskService.Create(taskDto);
        return Ok("Task created");
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TaskDTO taskDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _taskService.Update(taskDto);
        return Ok("Task updated");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _taskService.Delete(id);
        return Ok("Task deleted");
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] string status, string assignedTo)
    {
        var tasks = await _taskService.Filter(status, assignedTo);
        return Ok(tasks);
    }
}