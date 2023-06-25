using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class UserMySQLInfrastructure : IUserInfrastructure
{
    private readonly SignLingoDbContext _signLingoDbContext;

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

    public async Task<User> SignUp(User user)
    {
        await _signLingoDbContext.User.AddAsync(user);
        user.city = await _signLingoDbContext.City.FindAsync(user.CityId);
        await _signLingoDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetByUserEmailAsync(string email)
    {
        var user = await _signLingoDbContext.User.SingleAsync(user => user.Email == email);
        user.city = await _signLingoDbContext.City.FindAsync(user.CityId);
        return user;
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
        var userFound = await _signLingoDbContext.User.FindAsync(id);

        userFound.First_Name = user.First_Name;
        userFound.Last_Name = user.Last_Name;
        userFound.BirthDate = user.BirthDate;
        userFound.Email = user.Email;
        userFound.CityId = user.CityId;

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