using System.ComponentModel.DataAnnotations;

namespace SignLingo.API.Request;

public class UserRequest
{
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string First_Name { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string Last_Name { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(8)]
    public string? Password { get; set; }

    [Required]
    [MaxLength(30)]
    [EmailAddress]
    [MinLength(4)]
    public string? Email { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(3)]
    public string? Roles { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public string? BirthDate { get; set; }

    [Required]
    public int City { get; set; }
}