using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public interface IUserDomain
{
    public Task<bool> SaveAsync(User user);
    public Task<bool> UpdateAsync(int id, User user);
    public Task<bool> DeleteAsync(int id);
}