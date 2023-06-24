using System.ComponentModel.DataAnnotations.Schema;

namespace SignLingo.Infrastructure.Models;

public class User : BaseModel
{
    public string? First_Name { get; set; }
    public string? Last_Name { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public string? Roles { get; set; }

    [NotMapped]
    public City city { get; set; }
    
    public List<UserModule> UserModule { get; set; }
}