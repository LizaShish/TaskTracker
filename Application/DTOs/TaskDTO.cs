using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.DTOs;

public class TaskDTO
{
    
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string Status { get; set; }
    public string AssignedTo { get; set; }
    [Required]
    [JsonPropertyName("createBy")]
    public string CreateBy { get; set; }
    public DateTime CreateDate { get; set; } 
    public DateTime UpdateDate { get; set; }
   
}