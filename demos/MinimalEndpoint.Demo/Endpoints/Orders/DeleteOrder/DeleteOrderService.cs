namespace MinimalEndpoint.Demo.Endpoints.Orders.DeleteOrder;

public class DeleteOrderService : IDeleteOrderService
{
    public async Task Handle(
        DeleteOrderRequest request,
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}
