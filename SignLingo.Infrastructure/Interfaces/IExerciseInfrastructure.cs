using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface IExerciseInfrastructure
{
    Task<List<Exercise>> GetAllAsync();
    Task<List<Exercise>> GetByModuleIdAsync(int moduleId);
    public Task<List<Exercise>> GetExercisesByModuleNameAsync(string moduleName);
    public Task<Exercise> GetByIdAsync(int exerciseId);
    public Task<bool> SaveAsync(Exercise exercise);
    public Task<bool> UpdateAsync(int id, Exercise exercise);
    public Task<bool> DeleteAsync(int id);

}