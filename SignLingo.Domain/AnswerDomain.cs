using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class AnswerDomain : IAnswerDomain
{
    private IAnswerInfrastructure _answerInfrastructure;

    public AnswerDomain(IAnswerInfrastructure _answerInfrastructure)
    {
        this._answerInfrastructure = _answerInfrastructure;
    }
    
    public async Task<bool> SaveAsync(Answer answer)
    {
        if (!IsValidData(answer)) throw new Exception("must follow the user format");

        return await  _answerInfrastructure.SaveAsync(answer);
    }

    public async Task<bool> UpdateAsync(int id, Answer answer)
    {
        if (!IsValidData(answer)) throw new Exception("must follow the user format");
        return await _answerInfrastructure.UpdateAsync(id, answer);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!IsValidId(id)) throw new Exception("id must be greater than zero");
        return await _answerInfrastructure.DeleteAsync(id);
    }
    
    private bool IsValidData(Answer answer)
    {
        return answer.Answer_text.Length > 1; 
    }

    private bool IsValidId(int id)
    {
        return id > 0;
    }
}