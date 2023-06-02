namespace SignLingo.Infrastructure.Models;

public class Country
{
    public int Id { get; set; }
    public string Country_Name { get; set; }
    public List<City> Cities { get; set; }
}