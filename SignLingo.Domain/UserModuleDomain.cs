using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class UserModuleDomain : IUserModuleDomain
{
    private readonly IUserModuleInfrastructure _userModuleInfrastructure;

    public UserModuleDomain(IUserModuleInfrastructure userModuleInfrastructure)
    {
        _userModuleInfrastructure = userModuleInfrastructure;
    }
    
    public async Task<bool> SaveAsync(UserModule userModule)
    {
        if (!IsValidId(userModule.UserId) && !IsValidId(userModule.ModuleId)) throw new Exception("id must be greater than zero");
        return await _userModuleInfrastructure.SaveAsync(userModule);
    }

    public async Task<bool> UpdateAsync(int userId, int moduleId, UserModule userModule)
    {
        if (!IsValidId(userId) && !IsValidId(moduleId)) throw new Exception("id must be greater than zero");
        return await _userModuleInfrastructure.UpdateAsync(userId, moduleId, userModule);
    }

    public async Task<bool> DeleteAsync(int userId, int moduleId)
    {
        if (!IsValidId(userId) && !IsValidId(moduleId)) throw new Exception("id must be greater than zero");
        return await _userModuleInfrastructure.DeleteAsync(userId, moduleId);
    }
    
    private bool IsValidId(int id)
    {
        return id > 0;
    }
}