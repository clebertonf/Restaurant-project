using MediatR;

namespace Restaurant.Application.CQRS.Order.Queries;

public class OrderByIdQuery : IRequest<IEnumerable<Domain.Entities.Order>>, IRequest<Domain.Entities.Order>
{
    public int Id { get; set; }

    public OrderByIdQuery(int id)
    {
        Id = id;
    }
}