using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain.Interfaces;
public interface IModuleDomain
{
    public Task<bool> SaveAsync(Module module);
    public Task<bool> UpdateAsync(int id, Module module);
    public Task<bool> DeleteAsync(int id);
}