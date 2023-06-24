using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class UserDomain : IUserDomain
{
    private readonly IUserInfrastructure _userInfrastructure;
    private readonly IEncryptDomain _encryptDomain;
    private readonly ITokenDomain _tokenDomain;

    public UserDomain(IUserInfrastructure userInfrastructure, IEncryptDomain encryptDomain, ITokenDomain tokenDomain)
    {
        _userInfrastructure = userInfrastructure;
        _encryptDomain = encryptDomain;
        _tokenDomain = tokenDomain;
    }

    public async Task<string> Login(User user)
    {
        var userFound = await _userInfrastructure.GetByUserEmailAsync(user.Email);
        
        if (_encryptDomain.Encrypt(user.Password) == userFound.Password)
        {
            return _tokenDomain.GenerateJwt(user.Email);
        }
        
        throw new ArgumentException("Invalid email or password");
    }

    public async Task<User> SignUp(User user)
    {
        user.Password = _encryptDomain.Encrypt(user.Password);
        return await _userInfrastructure.SignUp(user);
    }

    public async Task<User> GetByUserEmailAsync(string email)
    {
        return await _userInfrastructure.GetByUserEmailAsync(email);
    }

    public async Task<bool> SaveAsync(User user)
    {
        if (!IsValidData(user)) throw new Exception("must follow the user format");

        return await  _userInfrastructure.SaveAsync(user);
    }

    public async Task<bool> UpdateAsync(int id, User user)
    {
        if (!IsValidData(user)) throw new Exception("must follow the user format");
        return await _userInfrastructure.UpdateAsync(id, user);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!IsValidId(id)) throw new Exception("id must be greater than zero");
        return await _userInfrastructure.DeleteAsync(id);
    }
    
    private bool IsValidData(User user)
    {
        return user.First_Name.Length > 1 && user.Last_Name.Length > 1 && user.Email.Contains('@') &&
               user.CityId > 0;
    }

    private bool IsValidId(int id)
    {
        return id > 0;
    }
    
}