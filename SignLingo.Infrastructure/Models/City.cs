using System.ComponentModel.DataAnnotations.Schema;

namespace SignLingo.Infrastructure.Models;

public class City : BaseModel
{
    public string City_Name { get; set; }
    [NotMapped]
    public Country country;
    public List<User> Users { get; set; }
    public int CountryId { get; set; }
}