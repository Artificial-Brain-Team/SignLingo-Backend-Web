using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain.Interfaces;
public interface IUserDomain
{
    public Task<string> Login(User user);
    public Task<User> SignUp(User user);
    public Task<User> GetByUserEmailAsync(string email);
    public Task<bool> SaveAsync(User user);
    public Task<bool> UpdateAsync(int id, User user);
    public Task<bool> DeleteAsync(int id);
}