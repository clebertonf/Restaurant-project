using FluentAssertions;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Validation;

namespace Restaurant.Tests.DomainTests;

public class OrderTest
{
    [Fact]
    public void CreateOrder_WithValidParameters_ShouldCreateOrder()
    {
        Action  action = () => new Order(11, 120);
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    
    [Fact]
    public void CreateOrder_WithInValidTableNumber_ResultInvalidValidObject()
    {
        Action  action = () => new Order(-1, 120);
        action.Should().Throw<DomainExceptionValidation>().WithMessage("'TableNumber' must be greater than or equal to 0.");
    }
}