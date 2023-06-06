using System.ComponentModel.DataAnnotations;

namespace SignLingo.API.Request;

public class ModuleRequest
{
    [Microsoft.Build.Framework.Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Module_Name { get; set; }
}