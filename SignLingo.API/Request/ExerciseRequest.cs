using System.ComponentModel.DataAnnotations;

namespace SignLingo.API.Request;

public class ExerciseRequest
{
    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Question { get; set; } 
    
    [Required]
    [MinLength(2)]
    public string Image { get; set; }
    
    [Required]
    public int ModuleId { get; set; }
}