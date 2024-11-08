using Restaurant.Domain.Validation;

namespace Restaurant.Domain.Entities;

public class Order : Base
{
    public Order(int tableNumber, decimal total)
    {
        ValidateDomain(tableNumber);
        Date = DateTime.Now;
        Total = total;
    }
    
    public DateTime Date { get; set; }
    public int TableNumber { get; set; }
    public decimal Total { get; set; }
    public IList<MenuItem>? MenuItems { get; set; }
    
    private void ValidateDomain(int tableNumber)
    {
        DomainExceptionValidation.When(tableNumber <= 0, "'TableNumber' must be greater than or equal to 0.");
        TableNumber = tableNumber;
    }
}