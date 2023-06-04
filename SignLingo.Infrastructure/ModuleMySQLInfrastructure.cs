using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class ModuleMySQLInfrastructure : IModuleInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;

    public ModuleMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }

    public List<Module> GetAll()
    {
        return _signLingoDbContext.Module.ToList();
    }
}