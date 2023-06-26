using System.Text.Json.Serialization;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Request;

public class UserModuleRequest
{
    public string? UserEmail { get; set; }
    public string? ModuleName { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    [JsonIgnore]
    public Module? Module { get; set; }
    public int Grade { get; set; }
}