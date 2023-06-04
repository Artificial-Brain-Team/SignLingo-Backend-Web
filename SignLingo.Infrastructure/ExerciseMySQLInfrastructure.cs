using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public class ExerciseMySQLInfrastructure : IExerciseInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;

    public ExerciseMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }

    public async Task<List<Exercise>> GetAllAsync()
    {
        var exercises = await _signLingoDbContext.Exercise.ToListAsync();
        return exercises;
    }

    public async Task<List<Exercise>> GetByModuleIdAsync(int moduleId)
    {
        var exercises = await _signLingoDbContext.Exercise.Where(exercise => exercise.ModuleId == moduleId)
            .ToListAsync();
        return exercises;
    }

    public async Task<Exercise> GetByIdAsync(int exerciseId)
    {
        var exercise = await _signLingoDbContext.Exercise.FindAsync(exerciseId);
        return exercise;
    }
}