using Restaurant.Domain.Validation;

namespace Restaurant.Domain.Entities;

public class MenuItem : Base
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; } = default;
    public Order? Order { get; set; }

    public MenuItem(string? name, string? description, decimal price)
    {
       ValidateDomain(name, description, price);
    }
    public void ValidateDomain(string name, string? description, decimal price)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be empty");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be empty");
        DomainExceptionValidation.When(price < 0, "Price cannot be negative");
        Name = name;
        Description = description;
        Price = price;
    }
}