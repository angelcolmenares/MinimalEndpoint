namespace MinimalEndpoint.Demo.Endpoints.Orders.CreateOrder;

public class CreateOrderService : ICreateOrderService
{
    public async Task<CreateOrderResponse> Handle(
        CreateOrderRequest request,
        CancellationToken cancellationToken = default) 
    => 
    await Task.FromResult(new CreateOrderResponse
    { 
        Id = System.Guid.NewGuid().ToString(),
        Message = $"Order Created: {request.Description}" 
    });
}
