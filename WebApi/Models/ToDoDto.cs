using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public struct ToDoDto
{

    [JsonPropertyName("id")]
    [Display(Name = "id")]
    [Required]
    public uint Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ToDoStateDto State { get; set; }
}