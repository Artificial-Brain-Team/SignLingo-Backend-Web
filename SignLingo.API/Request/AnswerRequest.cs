using System.ComponentModel.DataAnnotations;

namespace SignLingo.API.Request;

public class AnswerRequest
{
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string Answer_Text { get; set; }
    [Required]
    public bool IsCorrect { get; set; }
    [Required]
    public int ExerciseId { get; set; }
    
}