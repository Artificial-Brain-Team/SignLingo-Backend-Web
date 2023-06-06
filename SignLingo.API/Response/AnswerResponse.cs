namespace SignLingo.API.Response;

public class AnswerResponse
{
    public int ExerciseId { get; set; }
    public string Answer_Text { get; set; }  
    public bool IsCorrect { get; set; }
}