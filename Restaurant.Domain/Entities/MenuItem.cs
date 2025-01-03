using Restaurant.Domain.Validation;
namespace Restaurant.Domain.Entities;

public sealed class MenuItem : EntityBase
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public bool Available { get; private set; } = false;
    public Order? Order { get; set; }

    public MenuItem(string? name, string? description, decimal price)
    {
       ValidateDomain(name, description, price);
    }
    private void ValidateDomain(string? name, string? description, decimal price)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be empty");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be empty");
        DomainExceptionValidation.When(price < 0, "Price cannot be negative");
        Name = name;
        Description = description;
        Price = price;
    }
}