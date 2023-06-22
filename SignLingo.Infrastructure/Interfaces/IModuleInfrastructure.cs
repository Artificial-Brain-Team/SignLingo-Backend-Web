using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface IModuleInfrastructure
{
    Task<List<Module>> GetAllAsync();
    public Task<Module> GetByIdAsync(int moduleId);
    public Task<bool> SaveAsync(Module module);
    public Task<bool> UpdateAsync(int id, Module module);
    public Task<bool> DeleteAsync(int id);
}