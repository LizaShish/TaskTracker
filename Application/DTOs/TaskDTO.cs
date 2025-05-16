using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class TaskDTO
{
    [Required]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string Status { get; set; }
    public string AssignedTo { get; set; }
    
    public DateTime CreateDate { get; set; } 
    public DateTime UpdateDate { get; set; }
   
}