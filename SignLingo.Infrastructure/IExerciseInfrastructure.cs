using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public interface IExerciseInfrastructure
{
    Task<List<Exercise>> GetAllAsync();
    Task<List<Exercise>> GetByModuleIdAsync(int moduleId);
    public Task<Exercise> GetByIdAsync(int exerciseId);

}