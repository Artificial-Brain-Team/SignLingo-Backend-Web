using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface ICountryInfrastructure
{
    Task<List<Country>> GetAllAsync();
    Task<Country> GetByIdAsync(int id);
    public Task<bool> SaveAsync(Country country);
    public Task<bool> UpdateAsync(int id, Country country);
    public Task<bool> DeleteAsync(int id);
}