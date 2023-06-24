using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain.Interfaces;
public interface IUserModuleDomain
{
    public Task<bool> SaveAsync(UserModule user);
    public Task<bool> UpdateAsync(int userId, int moduleId, UserModule user);
    public Task<bool> DeleteAsync(int userId, int moduleId);
}