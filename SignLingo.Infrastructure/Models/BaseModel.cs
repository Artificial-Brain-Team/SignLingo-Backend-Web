namespace SignLingo.Infrastructure.Models;

public class BaseModel
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }

    protected BaseModel()
    {
        DateCreated = DateTime.Now;
        DateUpdated = DateTime.Now;
    }
    
}