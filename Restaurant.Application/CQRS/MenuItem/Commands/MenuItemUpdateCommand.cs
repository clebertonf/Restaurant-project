namespace Restaurant.Application.CQRS.MenuItem.Commands;

public class MenuItemUpdateCommand : MenuItemCommand
{
    public int Id { get; set; }
}