namespace SignLingo.Infrastructure.Models;

public class Answer : BaseModel
{
    public string Answer_text { get; set; }
    public int ExerciseId { get; set; }
    public bool IsCorrect { get; set; }
}