using Restaurant.Domain.Validation;

namespace Restaurant.Domain.Entities;

public class Order : Base
{
    public Order(DateTime date, int tableNumber, decimal total)
    {
        ValidateDomain(tableNumber);
    }

    public DateTime Date { get; set; }
    public int TableNumber { get; set; }
    public decimal Total { get; set; }
    public IList<MenuItem>? MenuItems { get; set; }
    
    public void ValidateDomain(int tableNumber)
    {
        DomainExceptionValidation.When(tableNumber < 0, "'TableNumber' must be greater than or equal to 0.");
        Date = DateTime.Now;
        TableNumber = tableNumber;
        Total = 0;
    }
}