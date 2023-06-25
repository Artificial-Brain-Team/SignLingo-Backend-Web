using System.ComponentModel.DataAnnotations;

namespace SignLingo.API.Request;

public class ModuleRequest
{
    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Module_Name { get; set; }

    [Required]
    [DataType(DataType.ImageUrl)]
    public string Image { get; set; }
}