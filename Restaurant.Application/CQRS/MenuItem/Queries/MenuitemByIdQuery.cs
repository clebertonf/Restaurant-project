using MediatR;

namespace Restaurant.Application.CQRS.MenuItem.Queries;

public class MenuitemByIdQuery : IRequest<Domain.Entities.MenuItem>
{
    public int Id { get; set; }
    public MenuitemByIdQuery(int id)
    {
        Id = id;
    }
}