using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain.Interfaces;
public interface IExerciseDomain
{
    public Task<bool> SaveAsync(Exercise exercise);
    public Task<bool> UpdateAsync(int id, Exercise exercise);
    public Task<bool> DeleteAsync(int id);
}