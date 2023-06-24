using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class CountryMySQLInfrastructure : ICountryInfrastructure
{
    
    private SignLingoDbContext _signLingoDbContext;

    public CountryMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }
    
    public async Task<List<Country>> GetAllAsync()
    {
        return await _signLingoDbContext.Country.ToListAsync();
    }

    public async Task<Country> GetByIdAsync(int id)
    {
        return await _signLingoDbContext.Country.FindAsync(id);
    }

    public async Task<bool> SaveAsync(Country country)
    {
        await _signLingoDbContext.Country.AddAsync(country);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, Country country)
    {
        var countryFound = await _signLingoDbContext.Country.FindAsync(id);
        countryFound.Country_Name = country.Country_Name;
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var countryFounded = await _signLingoDbContext.Country.FindAsync(id);
        _signLingoDbContext.Country.Remove(countryFounded);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }
}