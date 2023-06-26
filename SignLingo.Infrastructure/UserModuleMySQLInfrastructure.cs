using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class UserModuleMySQLInfrastructure :  IUserModuleInfrastructure
{
    private readonly SignLingoDbContext _signLingoDbContext;

    public UserModuleMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }
    
    public async Task<List<UserModule>> GetAllAsync()
    {
        var usersModules = await _signLingoDbContext.UserModule.ToListAsync();

        foreach (var userModule in usersModules)
        {
            userModule.User = await _signLingoDbContext.User.FindAsync(userModule.UserId);
            userModule.Module = await _signLingoDbContext.Module.FindAsync(userModule.ModuleId);
        }

        return usersModules;
    }

    public async Task<Module> GetByModuleNameAsync(string moduleName)
    {
        return await _signLingoDbContext.Module.FirstAsync(module => module.Module_Name == moduleName);
    }

    public async Task<List<UserModule>> GetModulesByUserEmailAsync(string email)
    {
        
        var userRequested = await _signLingoDbContext.User.Where(user => user.Email == email).FirstAsync();
        var usersModules = await _signLingoDbContext.UserModule.Where(userModule => userModule.UserId == userRequested.Id).ToListAsync();

        foreach (var userModule in usersModules)
        {
            userModule.Module = await _signLingoDbContext.Module.FindAsync(userModule.ModuleId);
        }

        return usersModules;
    }

    public async Task<UserModule> GetByIdAsync(int userId, int moduleId)
    {
        var userModule = await _signLingoDbContext.UserModule.FindAsync(userId,moduleId);
        userModule.User = await _signLingoDbContext.User.FindAsync(userModule.UserId);
        userModule.Module = await _signLingoDbContext.Module.FindAsync(userModule.ModuleId);
        return userModule;
    }

    public async Task<User> GetByUserEmailAsync(string email)
    {
        return await _signLingoDbContext.User.FirstAsync(user => user.Email == email);
    }

    public async Task<bool> SaveAsync(UserModule userModule)
    {
        await _signLingoDbContext.UserModule.AddAsync(userModule);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int userId, int moduleId, UserModule userModule)
    {
        var userModuleFound = await _signLingoDbContext.UserModule.FindAsync(userId, moduleId);
        userModuleFound.UserId = userModule.UserId;
        userModuleFound.ModuleId = userModule.ModuleId;
        userModuleFound.Grade = userModule.Grade;
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int userId, int moduleId)
    {
        var userModule = await _signLingoDbContext.UserModule.FindAsync(userId, moduleId);
        _signLingoDbContext.UserModule.Remove(userModule);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }
}