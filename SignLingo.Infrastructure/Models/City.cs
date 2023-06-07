using System.ComponentModel.DataAnnotations.Schema;

namespace SignLingo.Infrastructure.Models;

public class City
{
    public int Id { get; set; }
    public string City_Name { get; set; }
    [NotMapped]
    public Country country;
    public List<User> Users { get; set; }
    public int CountryId { get; set; }
}