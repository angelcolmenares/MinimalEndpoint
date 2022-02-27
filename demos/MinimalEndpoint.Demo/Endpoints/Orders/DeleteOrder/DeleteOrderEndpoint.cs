using Microsoft.AspNetCore.Mvc;

namespace MinimalEndpoint.Demo.Endpoints.Orders.DeleteOrder;

public class DeleteOrderEndpoint :
 EndpointDeleteWith<
 DeleteOrderRequest, 
 IResult, 
 IDeleteOrderService>,
 IEndpoint
{
    protected override RequestDelegate RequestHandler => Handle;

    private async Task<IResult> Handle(
        [FromBody] DeleteOrderRequest request,
        HttpContext httpContext,
        IDeleteOrderService service,
        CancellationToken cancellationToken)
    {
        await service.Handle(request, cancellationToken);
        return Results.NoContent();
    }
}