using MediatR;

namespace Restaurant.Application.CQRS.MenuItem.Commands;

public class MenuItemRemoveCommand : IRequest<Domain.Entities.MenuItem>
{
    public int Id { get; set; }
    public MenuItemRemoveCommand(int id)
    {
        Id = id;
    }
}