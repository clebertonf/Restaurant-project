using MediatR;

namespace Restaurant.Application.CQRS.MenuItem.Queries;

public class MenuItemByIdQuery : IRequest<Domain.Entities.MenuItem>
{
    public int Id { get; set; }
    public MenuItemByIdQuery(int id)
    {
        Id = id;
    }
}