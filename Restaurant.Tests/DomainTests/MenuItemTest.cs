using FluentAssertions;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Validation;

namespace Restaurant.Tests.DomainTests;

public class MenuItemTest
{
    [Fact]
    public void CreateMenuItem_WithValidParameters_SholdCreateAMenuItem()
    {
        Action action = () => new MenuItem("Test", "test description", 100);
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateMenuItem_WithInvalidName_ResultInvalidValidObject()
    {
        Action action = () => new MenuItem(String.Empty, "test description", 100);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Name cannot be empty");
    }
    
    [Fact]
    public void CreateMenuItem_WithInvalidDescription_ResultInvalidValidObject()
    {
        Action action = () => new MenuItem("Test", String.Empty, 100);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Description cannot be empty");
    }
    
    [Fact]
    public void CreateMenuItem_WithInvalidPrice_ResultInvalidValidObject()
    {
        Action action = () => new MenuItem("Test", "test description", -10);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Price cannot be negative");
    }
}