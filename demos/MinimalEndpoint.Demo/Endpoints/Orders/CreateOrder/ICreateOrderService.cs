namespace MinimalEndpoint.Demo.Endpoints.Orders.CreateOrder;

public interface ICreateOrderService
{
    Task<CreateOrderResponse> Handle(
        CreateOrderRequest request,
        CancellationToken cancellationToken = default);
}
