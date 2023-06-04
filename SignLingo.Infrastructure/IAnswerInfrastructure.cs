using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public interface IAnswerInfrastructure
{
    Task<List<Answer>> GetAllAsync();
    Task<List<Answer>> GetByExerciseIdAsync(int exerciseId);
}