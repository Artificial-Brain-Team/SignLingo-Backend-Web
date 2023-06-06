using System.ComponentModel.DataAnnotations;

namespace SignLingo.API.Request;

public class ModuleRequest
{
    [Microsoft.Build.Framework.Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string Module_Name { get; set; }
}