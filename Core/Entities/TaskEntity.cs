using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class TaskEntity
{
    [Key]
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string CreateBy { get; set; }
    public string AssignedTo { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
}