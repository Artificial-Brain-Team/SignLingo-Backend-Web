using AutoMapper;
using SignLingo.API.Response;
using SignLingo.Infrastructure.Models;
namespace SignLingo.API.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>()
            .ForMember(userResponse => userResponse.City, opt => opt.MapFrom(user => user.city.City_Name))
            .ForMember(userResponse => userResponse.BirthDay, opt => opt.MapFrom(user => user.BirthDate.Date));
        CreateMap<Country, CountryResponse>()
            .ForMember(userResponse => userResponse.id, opt => opt.MapFrom(country => country.Id))
            .ForMember(userResponse => userResponse.Country_name, opt => opt.MapFrom(country => country.Country_Name));
        CreateMap<City, CityResponse>()
            .ForMember(cityResponse => cityResponse.City_Name, opt => opt.MapFrom(city => city.City_Name))
            .ForMember(cityResponse => cityResponse.Country_name, opt => opt.MapFrom(city => city.country.Country_Name));
    }
}