using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain.Interfaces;
public interface ICountryDomain
{
    public Task<bool> SaveAsync(Country country);
    public Task<bool> UpdateAsync(int id, Country country);
    public Task<bool> DeleteAsync(int id);
}