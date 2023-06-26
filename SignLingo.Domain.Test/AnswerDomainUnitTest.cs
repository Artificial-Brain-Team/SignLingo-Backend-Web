using SignLingo.Infrastructure.Models;
using Moq;
using SignLingo.Infrastructure.Interfaces;

namespace SignLingo.Domain.Test;

public class AnswerDomainUnitTest
{
    [Fact]
    public async Task save_ValidObject_ReturnTrue()
    {
        //Arrange
        Answer answer = new Answer()
        {
            Answer_text = "Option1", 
            ExerciseId = 1,
            IsCorrect = true
        };
        
        //Mock
        var answerInfrastructure = new Mock<IAnswerInfrastructure>();
        answerInfrastructure.Setup(t => t.SaveAsync(answer)).ReturnsAsync(true);
        AnswerDomain answerDomain = new AnswerDomain(answerInfrastructure.Object);
        
        //Act
        var result = await answerDomain.SaveAsync(answer);
        
        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public async Task save_InvalidObject_ReturnTrue()
    {
        //Arrange
        Answer answer = new Answer()
        {
            Answer_text = "", 
            ExerciseId = 1,
            IsCorrect = true
        };
        
        //Mock
        var answerInfrastructure = new Mock<IAnswerInfrastructure>();
        answerInfrastructure.Setup(t => t.SaveAsync(answer)).ReturnsAsync(true);
        AnswerDomain answerDomain = new AnswerDomain(answerInfrastructure.Object);

        //Act
        var ex = await Assert.ThrowsAsync<Exception>(() => answerDomain.SaveAsync(answer));
        
        //Assert
        Assert.Equal("must follow the user format", ex.Message);
    }
}