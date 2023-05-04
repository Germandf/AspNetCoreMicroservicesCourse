using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrders;

public class GetOrdersQuery : IRequest<List<OrderVm>>
{
    public string UserName { get; set; }

    public GetOrdersQuery(string userName)
    {
        UserName = userName;
    }
}
