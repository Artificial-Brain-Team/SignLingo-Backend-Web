using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;

namespace SignLingo.Domain;

public class ExerciseDomain : IExerciseDomain
{
    private IExerciseInfrastructure _exerciseInfrastructure;

    public ExerciseDomain(IExerciseInfrastructure _exerciseInfrastructure)
    {
        this._exerciseInfrastructure = _exerciseInfrastructure;
    }
    
    public async Task<bool> SaveAsync(Exercise exercise)
    {
        if (!IsValidData(exercise)) throw new Exception("must follow the user format");

        return await  _exerciseInfrastructure.SaveAsync(exercise);
    }

    public async Task<bool> UpdateAsync(int id, Exercise exercise)
    {
        if (!IsValidData(exercise)) throw new Exception("must follow the user format");
        return await _exerciseInfrastructure.UpdateAsync(id, exercise);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (!IsValidId(id)) throw new Exception("id must be greater than zero");
        return await _exerciseInfrastructure.DeleteAsync(id);
    }
    
    private bool IsValidData(Exercise exercise)
    {
        return exercise.Question.Length > 1; 
    }
    private bool IsValidId(int id)
    {
        return id > 0;
    }
}