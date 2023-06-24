namespace SignLingo.Infrastructure.Models;

public class Exercise : BaseModel
{
    public string Question { get; set; }
    public List<Answer> Answers { get; set; }
    public string Image { get; set; }
    public int ModuleId { get; set; }
}