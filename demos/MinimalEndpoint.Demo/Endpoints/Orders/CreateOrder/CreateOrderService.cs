namespace MinimalEndpoint.Demo.Endpoints.Orders.CreateOrder;

public class CreateOrderService 
: OrdersCommandService<CreateOrderRequest, CreateOrderResponse>,
ICreateOrderService
{
    
  
    protected override async Task<CreateOrderResponse> Execute(
        CreateOrderRequest request,
        CancellationToken cancellationToken = default) 
    => 
    await Task.FromResult(new CreateOrderResponse
    { 
        Id = System.Guid.NewGuid().ToString(),
        Message = $"Order Created: {request.Description}" 
    });
    
}
