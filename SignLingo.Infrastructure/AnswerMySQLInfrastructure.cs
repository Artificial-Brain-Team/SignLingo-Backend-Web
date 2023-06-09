﻿
using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;
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

    public async Task<bool> SaveAsync(Answer answer)
    {
        await _signLingoDbContext.Answers.AddAsync(answer);
        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, Answer answer)
    {
        var answerFounded = await _signLingoDbContext.Answers.FindAsync(id);

        answerFounded.Answer_text = answer.Answer_text;
        answerFounded.IsCorrect = answer.IsCorrect;
        answerFounded.ExerciseId = answer.ExerciseId;

        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var answerFounded = await _signLingoDbContext.Answers.FindAsync(id);
        _signLingoDbContext.Answers.Remove(answerFounded);
        _signLingoDbContext.SaveChangesAsync();
        return true;  
    }

}