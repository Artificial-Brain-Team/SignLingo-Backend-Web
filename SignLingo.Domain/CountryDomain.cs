using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;
namespace SignLingo.Domain;

public class CountryDomain : ICountryDomain
{
    private ICountryInfrastructure _countryInfrastructure;

    public CountryDomain(ICountryInfrastructure countryInfrastructure)
    {
        _countryInfrastructure = countryInfrastructure;
    }
    
    public async Task<bool> SaveAsync(Country country)
    {
        if (!IsValidCountry(country)) throw new Exception("Country name must initialize in capital letter");
        return await _countryInfrastructure.SaveAsync(country);
    }

    public async Task<bool> UpdateAsync(int id, Country country)
    {
        if (!IsValidCountry(country)) throw new Exception("Country name must initialize in capital letter");
        return await _countryInfrastructure.UpdateAsync(id, country);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!IsValidId(id)) throw new Exception("id must be greater than zero");
        return await _countryInfrastructure.DeleteAsync(id);
    }

    private bool IsValidCountry(Country country)
    {
        return Char.IsUpper(country.Country_Name[0]);
    }
    
    private bool IsValidId(int id)
    {
        return id > 0;
    }
    
}