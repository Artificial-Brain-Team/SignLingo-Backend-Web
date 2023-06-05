using System.ComponentModel.DataAnnotations;
namespace SignLingo.API.Request;

public class CityRequest
{
    [Required]
    [MaxLength(20)]
    public string City_Name { get; set; }
    [Required]
    public int Country { get; set; }
}