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
            .ForMember(userResponse => userResponse.BirthDay, opt => opt.MapFrom(user => user.BirthDate.Date))
            .ForMember(userResponse => userResponse.Type, opt => opt.MapFrom(user => user.Type));
        CreateMap<Country, CountryResponse>()
            .ForMember(userResponse => userResponse.id, opt => opt.MapFrom(country => country.Id))
            .ForMember(userResponse => userResponse.Country_name, opt => opt.MapFrom(country => country.Country_Name));
        CreateMap<City, CityResponse>()
            .ForMember(cityResponse => cityResponse.City_Name, opt => opt.MapFrom(city => city.City_Name))
            .ForMember(cityResponse => cityResponse.Country_name, opt => opt.MapFrom(city => city.country.Country_Name));
        CreateMap<Module, ModuleResponse>()
            .ForMember(moduleResponse => moduleResponse.Module_Name, opt => opt.MapFrom(module => module.Module_Name));
        CreateMap<Exercise, ExerciseResponse>()
            .ForMember(exerciseResponse => exerciseResponse.Question, opt => opt.MapFrom(exercise => exercise.Question))
            .ForMember(exerciseResponse => exerciseResponse.Image, opt => opt.MapFrom(exercise => exercise.Image))
            .ForMember(exerciseResponse => exerciseResponse.ModuleName, opt => opt.MapFrom(exercise => exercise.Module.Module_Name))
            .ForMember(exerciseResponse => exerciseResponse.ExerciseId, opt => opt.MapFrom(exercise => exercise.Id));
        CreateMap<Answer, AnswerResponse>()
            .ForMember(answerResponse => answerResponse.Answer_Text, opt => opt.MapFrom(answer => answer.Answer_text))
            .ForMember(answerResponse => answerResponse.ExerciseId, opt => opt.MapFrom(answer => answer.ExerciseId))
            .ForMember(answerResponse => answerResponse.IsCorrect, opt => opt.MapFrom(answer => answer.IsCorrect));
        CreateMap<UserModule, UserModuleResponse>()
            .ForMember(userModuleResponse => userModuleResponse.User, opt => opt.MapFrom(userModule => $"{userModule.User.First_Name} {userModule.User.Last_Name}"))
            .ForMember(userModuleResponse => userModuleResponse.Email, opt => opt.MapFrom(userModule => userModule.User.Email))
            .ForMember(userModuleResponse => userModuleResponse.Module, opt => opt.MapFrom(userModule => userModule.Module.Module_Name))
            .ForMember(userModuleResponse => userModuleResponse.Image, opt => opt.MapFrom(userModule => userModule.Module.Image))
            .ForMember(userModuleResponse => userModuleResponse.Unit, opt => opt.MapFrom(userModule => userModule.Module.Unit))
            .ForMember(userModuleResponse => userModuleResponse.Grade, opt => opt.MapFrom(userModule => userModule.Grade));
    }
}