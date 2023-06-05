using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public interface ICityDomain
{
    public Task<bool> SaveAsync(City city);
    public Task<bool> UpdateAsync(int id, City city);
    public Task<bool> DeleteAsync(int id);
}