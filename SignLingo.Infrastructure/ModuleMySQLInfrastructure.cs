using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class ModuleMySQLInfrastructure : IModuleInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;

    public ModuleMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }

    public async Task<List<Module>> GetAllAsync()
    {
        var modules = await _signLingoDbContext.Module.ToListAsync();
        return modules;
    }

    public async Task<Module> GetByIdAsync(int moduleId)
    {
        var module = await _signLingoDbContext.Module.FindAsync(moduleId);
        return module;
    }

    public async Task<bool> SaveAsync(Module module)
    {
        await _signLingoDbContext.Module.AddAsync(module);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, Module module)
    {
        var moduleFounded = await _signLingoDbContext.Module.FindAsync(id);

        moduleFounded.Module_Name = module.Module_Name;

        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var moduleFounded = await _signLingoDbContext.Module.FindAsync(id);
        _signLingoDbContext.Module.Remove(moduleFounded);
        _signLingoDbContext.SaveChangesAsync();
        return true;  
    }
}