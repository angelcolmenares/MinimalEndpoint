namespace MinimalEndpoint.Demo.Endpoints.Orders.UpdateOrderDescription;

public interface IUpdateOrderDescriptionService
{
    Task Handle(UpdateOrdeDescriptionRequest request, CancellationToken cancellationToken = default);
}
