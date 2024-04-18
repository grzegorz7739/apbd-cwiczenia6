using System.ComponentModel.DataAnnotations;

namespace ProjectAnimals.Controllers.DTOs;

public class UpdateAnimals
{
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }
}