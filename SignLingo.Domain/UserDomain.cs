using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class UserDomain : IUserDomain
{
    private IUserInfrastructure _userInfrastructure;

    public UserDomain(IUserInfrastructure userInfrastructure)
    {
        _userInfrastructure = userInfrastructure;
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