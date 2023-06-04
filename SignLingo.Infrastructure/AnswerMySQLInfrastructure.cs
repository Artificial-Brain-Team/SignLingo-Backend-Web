
using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

public class AnswerMySQLInfrastructure : IAnswerInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;

    public AnswerMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }

    public async Task<List<Answer>> GetAllAsync()
    {
        var answers = await _signLingoDbContext.Answers.ToListAsync();

        return answers;    
    }

    public async Task<List<Answer>> GetByExerciseIdAsync(int exerciseId)
    {
        var answers = await _signLingoDbContext.Answers.Where(answer => answer.ExerciseId == exerciseId).ToListAsync();
        
        return answers;
    }
    

}