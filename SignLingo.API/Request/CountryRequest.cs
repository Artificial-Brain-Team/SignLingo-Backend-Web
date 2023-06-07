using System.ComponentModel.DataAnnotations;
namespace SignLingo.API.Request;

public class CountryRequest
{
    [Required]
    [MaxLength(20)]
    public string Country_Name { get; set; }
}