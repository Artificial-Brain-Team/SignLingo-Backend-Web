namespace SignLingo.Infrastructure.Models;

public class Module : BaseModel
{
    public string Module_Name { get; set; }
    public List<Exercise> Exercises { get; set; }
    public List<UserModule> UserModule { get; set; }
}