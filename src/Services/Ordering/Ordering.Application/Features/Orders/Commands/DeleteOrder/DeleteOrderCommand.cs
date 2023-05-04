using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest
{
    public required int Id { get; set; }
}
