using AutoMapper;
using SignLingo.API.Request;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<UserRequest, User>();
    }
}