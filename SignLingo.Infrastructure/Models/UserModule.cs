namespace SignLingo.Infrastructure.Models;

public class UserModule
{
    public int UserId { get; set; }
    public int ModuleId { get; set; }
    public int Grade { get; set; }
    public User User { get; set; } = null!;
    public Module Module { get; set; } = null!;
}