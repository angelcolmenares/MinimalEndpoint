namespace MinimalEndpoint.Demo.Endpoints.Orders.CreateOrder;

public class CreateOrderEndpoint :
EndpointPost<
CreateOrderRequest, 
CreateOrderResponse, 
ICreateOrderService>
{
    protected override RequestDelegate RequestHandler => Handle;

    private async Task<CreateOrderResponse> Handle(
        CreateOrderRequest request,
        HttpContext httpContext,
        ICreateOrderService service,
        CancellationToken cancellationToken=default)
    {
        return await service.Handle(request,cancellationToken);
    }
}
