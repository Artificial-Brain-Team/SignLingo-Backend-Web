using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class ModuleDomain : IModuleDomain
{
    private IModuleInfrastructure _moduleInfrastructure;

    public ModuleDomain(IModuleInfrastructure _moduleInfrastructure)
    {
        this._moduleInfrastructure = _moduleInfrastructure;
    }
    
    public async Task<bool> SaveAsync(Module module)
    {
        if (!IsValidData(module)) throw new Exception("must follow the user format");

        return await  _moduleInfrastructure.SaveAsync(module);
    }

    public async Task<bool> UpdateAsync(int id, Module module)
    {
        if (!IsValidData(module)) throw new Exception("must follow the user format");
        return await _moduleInfrastructure.UpdateAsync(id, module);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!IsValidId(id)) throw new Exception("id must be greater than zero");
        return await _moduleInfrastructure.DeleteAsync(id);
    }
    
    private bool IsValidData(Module module)
    {
        return module.Module_Name.Length > 1; 
    }
    private bool IsValidId(int id)
    {
        return id > 0;
    }
}