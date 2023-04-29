﻿using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Data;

public class Todo
{
    [Required]
    public uint Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public ToDoState State { get; set; }
}