namespace SignLingo.Infrastructure.Models;

public class Answer
{
    public int Id { get; set; }
    public string Answer_text { get; set; }
    public int ExerciseId { get; set; }
    public bool IsCorrect { get; set; }
}