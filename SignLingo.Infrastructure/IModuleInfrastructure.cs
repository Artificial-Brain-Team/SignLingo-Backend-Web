using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public interface IModuleInfrastructure
{
    List<Module> GetAll();
}