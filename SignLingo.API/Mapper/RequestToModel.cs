using AutoMapper;
using SignLingo.API.Request;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<UserRequest, User>()
            .ForMember(user => user.First_Name, opt => opt.MapFrom(userRequest => userRequest.First_Name))
            .ForMember(user => user.Last_Name, opt =>opt.MapFrom(userRequest => userRequest.Last_Name))
            .ForMember(user => user.Email, opt => opt.MapFrom(userRequest => userRequest.Email))
            .ForMember(user => user.BirthDate, opt => opt.MapFrom(userRequest => DateTime.Parse(userRequest.BirthDate)))
            .ForMember(user => user.CityId, opt => opt.MapFrom(userRequest => userRequest.City))
            .ForMember(user => user.city, opt => opt.Ignore());
    }
}