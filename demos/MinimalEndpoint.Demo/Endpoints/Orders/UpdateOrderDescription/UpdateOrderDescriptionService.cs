namespace MinimalEndpoint.Demo.Endpoints.Orders.UpdateOrderDescription;

public class UpdateOrderDescriptionService : IUpdateOrderDescriptionService
{
    public async Task Handle(
        UpdateOrdeDescriptionRequest request,
        CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}