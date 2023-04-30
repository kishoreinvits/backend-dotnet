using System.ComponentModel.DataAnnotations;

namespace WebApi.Data;

public class ToDo
{
    [Required]
    public uint Id { get; set; }

    [Required]
    public string Description { get; set; } = "Default";
    
    [Required]
    public ToDoState State { get; set; }
}