namespace SignLingo.Domain.Interfaces;

public interface ITokenDomain
{
    public string GenerateJwt(string username);
    public string ValidateJwt(string token);
}