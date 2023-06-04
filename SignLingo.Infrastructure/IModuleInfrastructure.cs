using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public interface IModuleInfrastructure
{
    Task<List<Module>> GetAllAsync();
    public Task<Module> GetByIdAsync(int moduleId);
}