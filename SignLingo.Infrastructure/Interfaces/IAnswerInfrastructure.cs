using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure.Interfaces;

public interface IAnswerInfrastructure
{
    Task<List<Answer>> GetAllAsync();
    Task<List<Answer>> GetByExerciseIdAsync(int exerciseId);
    public Task<bool> SaveAsync(Answer user);
    public Task<bool> UpdateAsync(int id, Answer asnwer);
    public Task<bool> DeleteAsync(int id);
}