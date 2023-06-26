using SignLingo.Infrastructure.Models;
using Moq;
using SignLingo.Infrastructure.Interfaces;

namespace SignLingo.Domain.Test;

public class ModuleDomainUnitTest
{
    [Fact]
    public async Task save_ValidObject_ReturnTrue()
    {
        //Arrange
        Module module = new Module()
        {
            Module_Name = "Test Module",
            Unit = 1,
            Image = "Example1"
        };
        
        //Mock
        var moduleInfrastructure = new Mock<IModuleInfrastructure>();
        moduleInfrastructure.Setup(t => t.SaveAsync(module)).ReturnsAsync(true);
        ModuleDomain moduleDomain = new ModuleDomain(moduleInfrastructure.Object);
        
        //Act
        var result = await moduleDomain.SaveAsync(module);
        
        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public async Task save_InvalidUnit_ReturnTrue()
    {
        //Arrange
        Module module = new Module()
        {
            Module_Name = "Test Module",
            Unit = 0,
            Image = "Example1"
        };
        
        //Mock
        var moduleInfrastructure = new Mock<IModuleInfrastructure>();
        moduleInfrastructure.Setup(t => t.SaveAsync(module)).ReturnsAsync(true);
        ModuleDomain moduleDomain = new ModuleDomain(moduleInfrastructure.Object);
        
        //Act
        var ex = await Assert.ThrowsAsync<Exception>(() => moduleDomain.SaveAsync(module));
        
        //Assert
        Assert.Equal("must follow the user format", ex.Message);
    }
    
    [Fact]
    public async Task save_InvalidName_ReturnTrue()
    {
        //Arrange
        Module module = new Module()
        {
            Module_Name = "",
            Unit = 2,
            Image = "Example1"
        };
        
        //Mock
        var moduleInfrastructure = new Mock<IModuleInfrastructure>();
        moduleInfrastructure.Setup(t => t.SaveAsync(module)).ReturnsAsync(true);
        ModuleDomain moduleDomain = new ModuleDomain(moduleInfrastructure.Object);
        
        //Act
        var ex = await Assert.ThrowsAsync<Exception>(() => moduleDomain.SaveAsync(module));
        
        //Assert
        Assert.Equal("must follow the user format", ex.Message);
    }
    
    [Fact]
    public async Task save_InvalidImage_ReturnTrue()
    {
        //Arrange
        Module module = new Module()
        {
            Module_Name = "Test Module",
            Unit = 1,
            Image = ""
        };
        
        //Mock
        var moduleInfrastructure = new Mock<IModuleInfrastructure>();
        moduleInfrastructure.Setup(t => t.SaveAsync(module)).ReturnsAsync(true);
        ModuleDomain moduleDomain = new ModuleDomain(moduleInfrastructure.Object);
        
        //Act
        var ex = await Assert.ThrowsAsync<Exception>(() => moduleDomain.SaveAsync(module));
        
        //Assert
        Assert.Equal("must follow the user format", ex.Message);
    }
}