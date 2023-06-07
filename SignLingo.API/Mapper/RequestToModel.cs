using AutoMapper;
using SignLingo.API.Request;
using SignLingo.API.Response;
using SignLingo.Infrastructure.Models;

namespace SignLingo.API.Mapper;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<UserRequest, User>()
            .ForMember(user => user.First_Name, opt => opt.MapFrom(userRequest => userRequest.First_Name))
            .ForMember(user => user.Last_Name, opt => opt.MapFrom(userRequest => userRequest.Last_Name))
            .ForMember(user => user.Email, opt => opt.MapFrom(userRequest => userRequest.Email))
            .ForMember(user => user.BirthDate, opt => opt.MapFrom(userRequest => DateTime.Parse(userRequest.BirthDate)))
            .ForMember(user => user.CityId, opt => opt.MapFrom(userRequest => userRequest.City))
            .ForMember(user => user.city, opt => opt.Ignore());
        CreateMap<CountryRequest, Country>()
            .ForMember(country => country.Country_Name, opt => opt.MapFrom(countryRequest => countryRequest.Country_Name))
            .ForMember(country => country.Id, opt=>opt.Ignore())
            .ForMember(country => country.Cities, opt=>opt.Ignore());
        CreateMap<CityRequest, City>()
            .ForMember(city => city.City_Name, opt => opt.MapFrom(cityRequest => cityRequest.City_Name))
            .ForMember(city => city.CountryId, opt => opt.MapFrom(cityRequest => cityRequest.Country))
            .ForMember(city => city.country, opt => opt.Ignore())
            .ForMember(city => city.Users, opt => opt.Ignore());        
        CreateMap<ModuleRequest, Module>()
            .ForMember(module => module.Module_Name, opt => opt.MapFrom(moduleRequest => moduleRequest.Module_Name));
        CreateMap<ExerciseRequest, Exercise>()
            .ForMember(exercise => exercise.ModuleId, opt => opt.MapFrom(exerciseRequest => exerciseRequest.ModuleId))
            .ForMember(exercise => exercise.Question, opt => opt.MapFrom(exerciseRequest => exerciseRequest.Question))
            .ForMember(exercise => exercise.Image, opt => opt.MapFrom(exerciseRequest => exerciseRequest.Image));
        CreateMap<AnswerRequest, Answer>()
            .ForMember(answer => answer.ExerciseId, opt => opt.MapFrom(answerRequest => answerRequest.ExerciseId))
            .ForMember(answer => answer.Answer_text, opt => opt.MapFrom(answerRequest => answerRequest.Answer_Text))
            .ForMember(answer => answer.IsCorrect, opt => opt.MapFrom(answerRequest => answerRequest.IsCorrect));
        CreateMap<UserModuleRequest, UserModule>()
            .ForMember(userModule => userModule.ModuleId, opt => opt.MapFrom(userModuleRequest => userModuleRequest.ModuleId))
            .ForMember(userModule => userModule.UserId, opt => opt.MapFrom(userModuleRequest => userModuleRequest.UserId))
            .ForMember(userModule => userModule.Grade, opt => opt.MapFrom(userModuleRequest => userModuleRequest.Grade))
            .ForMember(userModule => userModule.User, opt => opt.Ignore())
            .ForMember(userModule => userModule.Module, opt => opt.Ignore());
    }
}