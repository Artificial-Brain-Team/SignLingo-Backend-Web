using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface IUserModuleInfrastructure
{
    Task<List<UserModule>> GetAllAsync();
    Task<UserModule> GetByIdAsync(int userId, int moduleId);
    public Task<bool> SaveAsync(UserModule userModule);
    public Task<bool> UpdateAsync(int userId, int moduleId, UserModule user);
    public Task<bool> DeleteAsync(int userId, int moduleId);
}