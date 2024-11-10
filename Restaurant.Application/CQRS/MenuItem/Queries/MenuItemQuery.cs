using MediatR;

namespace Restaurant.Application.CQRS.MenuItem.Queries;

public class MenuItemQuery : IRequest<IEnumerable<Domain.Entities.MenuItem>>
{
}