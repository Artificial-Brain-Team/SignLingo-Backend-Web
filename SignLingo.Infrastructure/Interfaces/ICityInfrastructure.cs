using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface ICityInfrastructure
{
    Task<List<City>> GetAllAsync();
    Task<City> GetByIdAsync(int id);
    public Task<bool> SaveAsync(City city);
    public Task<bool> UpdateAsync(int id, City city);
    public Task<bool> DeleteAsync(int id);
}