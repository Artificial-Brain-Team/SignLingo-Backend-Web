using SignLingo.Infrastructure.Interfaces;
using SignLingo.Infrastructure.Models;
using Moq;

namespace SignLingo.Domain.Test;

public class ExerciseDomainUnitTest
{
    [Fact]
    public async Task save_ValidObject_ReturnTrue()
    {
        //Arrange
        Exercise exercise = new Exercise()
        {
            Question = "¿Cual es manera correcta de saludar a un extraño?",
            Image = "example1.jpg",
            ModuleId = 2
        };
        
        //Mock
        var exerciseInfrastructure = new Mock<IExerciseInfrastructure>();
        exerciseInfrastructure.Setup(t => t.SaveAsync(exercise)).ReturnsAsync(true);
        ExerciseDomain exerciseDomain = new ExerciseDomain(exerciseInfrastructure.Object);
        
        //Act
        var result = await exerciseDomain.SaveAsync(exercise);
        
        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public async Task save_InvalidObject_ReturnTrue()
    {
        //Arrange
        Exercise exercise = new Exercise()
        {
            Question = "",
            Image = "example1.jpg",
            ModuleId = 2
        };
        
        //Mock
        var exerciseInfrastructure = new Mock<IExerciseInfrastructure>();
        exerciseInfrastructure.Setup(t => t.SaveAsync(exercise)).ReturnsAsync(true);
        ExerciseDomain exerciseDomain = new ExerciseDomain(exerciseInfrastructure.Object);
        
        //Act
        var ex = await Assert.ThrowsAsync<Exception>(() => exerciseDomain.SaveAsync(exercise));
        
        //Assert
        Assert.Equal("must follow the user format", ex.Message);
    }
}