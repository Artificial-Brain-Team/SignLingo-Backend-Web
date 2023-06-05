using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public interface IAnswerDomain
{
    public Task<bool> SaveAsync(Answer answer);
    public Task<bool> UpdateAsync(int id, Answer answer);
    public Task<bool> DeleteAsync(int id);
}