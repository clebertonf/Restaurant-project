namespace Restaurant.Application.CQRS.Order.Commands;

public class OrderUpdateCommand : OrderCommand
{
    public int Id { get; set; }
}