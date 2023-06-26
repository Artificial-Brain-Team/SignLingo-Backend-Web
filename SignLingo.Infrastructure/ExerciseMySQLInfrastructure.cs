using Microsoft.EntityFrameworkCore;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;
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

    public async Task<List<Exercise>> GetExercisesByModuleNameAsync(string moduleName)
    {
        var moduleRequested = await _signLingoDbContext.Module.Where(module => module.Module_Name == moduleName).FirstAsync();
        var exercises = await _signLingoDbContext.Exercise.Where(exercise => exercise.ModuleId == moduleRequested.Id).ToListAsync();
        foreach (var exercise in exercises)
        {
            exercise.Module = moduleRequested;
        }

        return exercises;
    }

    public async Task<Exercise> GetByIdAsync(int exerciseId)
    {
        var exercise = await _signLingoDbContext.Exercise.FindAsync(exerciseId);
        return exercise;
    }
    public async Task<bool> SaveAsync(Exercise exercise){
            await _signLingoDbContext.Exercise.AddAsync(exercise);
            await _signLingoDbContext.SaveChangesAsync();
            return true;
    }
    public async Task<bool> UpdateAsync(int id, Exercise exercise){
        var exerciseFounded = await _signLingoDbContext.Exercise.FindAsync(id);

        exerciseFounded.Question = exercise.Question;
        exerciseFounded.Image = exercise.Image;
        exerciseFounded.ModuleId = exercise.ModuleId;

        await _signLingoDbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id){
        var exerciseFounded = await _signLingoDbContext.Exercise.FindAsync(id);
        _signLingoDbContext.Exercise.Remove(exerciseFounded);
        _signLingoDbContext.SaveChangesAsync();
        return true;  
    }
}