using System.ComponentModel.DataAnnotations.Schema;

namespace SignLingo.Infrastructure.Models;

public class User
{
    public int Id { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string Email { get; set; }
    
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    
    [NotMapped]
    public City? city { get; set; }
    public  bool IsActive { get; set; }
}