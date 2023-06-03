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
    }
}