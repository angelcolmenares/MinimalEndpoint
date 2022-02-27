namespace MinimalEndpoint.Demo.Endpoints.Orders.DeleteOrder;

public interface IDeleteOrderService
{
    Task Handle(
        DeleteOrderRequest request,
        CancellationToken cancellationToken = default);
}
