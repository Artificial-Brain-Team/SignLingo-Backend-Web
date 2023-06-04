using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public interface IExerciseInfrastructure
{
    List<Exercise> GetAll();
}