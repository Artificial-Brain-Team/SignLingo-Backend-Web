namespace SignLingo.Infrastructure.Models;

public class Country : BaseModel
{
    public string Country_Name { get; set; }
    public List<City> Cities { get; set; }
}