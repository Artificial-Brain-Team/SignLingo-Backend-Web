using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class ModuleMySQLInfrastructure : IModuleInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;
    private IModuleInfrastructure _moduleInfrastructureImplementation;

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
}