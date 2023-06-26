using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface IUserModuleInfrastructure
{
    Task<List<UserModule>> GetAllAsync();
    Task<UserModule> GetByIdAsync(int userId, int moduleId);
    public Task<User> GetByUserEmailAsync(string email);
    public Task<Module> GetByModuleNameAsync(string moduleName);
    public Task<List<UserModule>> GetModulesByUserEmailAsync(string email);
    public Task<bool> SaveAsync(UserModule userModule);
    public Task<bool> UpdateAsync(int userId, int moduleId, UserModule user);
    public Task<bool> DeleteAsync(int userId, int moduleId);
}