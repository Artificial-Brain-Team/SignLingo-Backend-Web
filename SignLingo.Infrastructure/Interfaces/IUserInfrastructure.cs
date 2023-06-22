using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface IUserInfrastructure
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    public Task<bool> SaveAsync(User user);
    public Task<bool> UpdateAsync(int id, User user);
    public Task<bool> DeleteAsync(int id);
}