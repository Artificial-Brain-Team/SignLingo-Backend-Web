using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class UserMySQLInfrastructure : IUserInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;

    public UserMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }
    
    public async Task<List<User>> GetAllAsync()
    {
        var users = await _signLingoDbContext.User.Where(user => user.IsActive).ToListAsync();
        
        foreach (var user in users)
        {
            var city = await _signLingoDbContext.City.FindAsync(user.CityId);
            user.city = city;
        }

        return users;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _signLingoDbContext.User.FindAsync(id);
        var city = await _signLingoDbContext.City.FindAsync(user.CityId);
        user.city = city;
        return user;
    }

    public async Task<bool> SaveAsync(User user)
    {
        await _signLingoDbContext.User.AddAsync(user);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, User user)
    {
        var userFounded = await _signLingoDbContext.User.FindAsync(id);

        userFounded.First_Name = user.First_Name;
        userFounded.Last_Name = user.Last_Name;
        userFounded.BirthDate = user.BirthDate;
        userFounded.Email = user.Email;
        userFounded.CityId = user.CityId;

        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _signLingoDbContext.User.FindAsync(id);
        user.IsActive = false;
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }
}