using MinimalApis.Extensions.Binding;

namespace MinimalEndpoint.Demo.Endpoints.Orders.GetOrderById;

public class GetOrderByIdEndpoint :
EndpointGet<
ModelBinder<GetOrderByIdRequest>,
GetOrderByIdResponse,
IGetOrderByIdService>
{
    protected override RequestDelegate RequestHandler => Handle;

    private async Task<GetOrderByIdResponse> Handle(
        ModelBinder<GetOrderByIdRequest> request,
        HttpContext httpContext,
        IGetOrderByIdService service,
        CancellationToken cancellationToken)
    {
        if( request.Model is null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        var results=await service.Handle(
            request.Model, 
            cancellationToken);
        return results;
    }
}
