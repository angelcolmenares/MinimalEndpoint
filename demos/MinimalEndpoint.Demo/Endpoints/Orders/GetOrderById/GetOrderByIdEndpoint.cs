namespace MinimalEndpoint.Demo.Endpoints.Orders.GetOrderById;

public class GetOrderByIdEndpoint :
EndpointGetWith<
string,
GetOrderByIdResponse,
IGetOrderByIdService>,
IEndpoint

{
    protected override RequestDelegate RequestHandler => Handle;

    private async Task<GetOrderByIdResponse> Handle(
        string id,
        HttpContext httpContext,
        IGetOrderByIdService service,
        CancellationToken cancellationToken)
    {
        var results=await service.Handle(
            new GetOrderByIdRequest { Id = id }, 
            cancellationToken);
        return results;
    }
}
