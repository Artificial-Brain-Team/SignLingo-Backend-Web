using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class CityMySQLInfrastructure : ICityInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;
    
    public CityMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }
    
    public async Task<List<City>> GetAllAsync()
    {
        var cities = await _signLingoDbContext.City.ToListAsync();

        foreach (var city in cities)
        {
            city.country = await _signLingoDbContext.Country.FindAsync(city.CountryId);
        }

        return cities;
    }

    public async Task<City> GetByIdAsync(int id)
    {
        var city = await _signLingoDbContext.City.FindAsync(id);
        city.country = await _signLingoDbContext.Country.FindAsync(city.CountryId);
        return city;
    }

    public async Task<bool> SaveAsync(City city)
    {
        await _signLingoDbContext.City.AddAsync(city);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, City city)
    {
        var cityFound = await _signLingoDbContext.City.FindAsync(id);
        cityFound.City_Name = city.City_Name;
        cityFound.CountryId = city.CountryId;
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cityFound = await _signLingoDbContext.City.FindAsync(id);
        _signLingoDbContext.Remove(cityFound);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }
}