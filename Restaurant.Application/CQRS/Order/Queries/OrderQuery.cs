using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.Order.Queries;

public class OrderQuery : IRequest<IEnumerable<Domain.Entities.Order>>
{
}