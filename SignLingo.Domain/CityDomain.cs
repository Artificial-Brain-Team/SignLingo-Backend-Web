using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class CityDomain : ICityDomain
{
    private ICityInfrastructure _cityInfrastructure;

    public CityDomain(ICityInfrastructure cityInfrastructure)
    {
        _cityInfrastructure = cityInfrastructure;
    }
    
    public async Task<bool> SaveAsync(City city)
    {
        if (!IsValidCity(city)) throw new Exception("City name must initialize in capital letter");
        return await _cityInfrastructure.SaveAsync(city);
    }

    public async Task<bool> UpdateAsync(int id, City city)
    {
        if (!IsValidCity(city)) throw new Exception("City name must initialize in capital letter");
        return await _cityInfrastructure.UpdateAsync(id, city);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!IsValidId(id)) throw new Exception("id must be greater than zero");
        return await _cityInfrastructure.DeleteAsync(id);
    }
    
    private bool IsValidCity(City city)
    {
        return Char.IsUpper(city.City_Name[0]);
    }
    
    private bool IsValidId(int id)
    {
        return id > 0;
    }
}