namespace MinimalEndpoint.Demo.Endpoints.Orders.UpdateOrderDescription;

public class UpdateOrderDescriptionEndpoint : 
EndpointPutWith<
UpdateOrdeDescriptionRequest, 
IResult, 
IUpdateOrderDescriptionService>, IEndpoint
{
    protected override RequestDelegate RequestHandler => Handle;

    private async Task<IResult> Handle(
        UpdateOrdeDescriptionRequest request,
        HttpContext httpContext,
        IUpdateOrderDescriptionService service,
        CancellationToken cancellationToken=default)
    {
        await service.Handle(request, cancellationToken);
        return Results.NoContent();
    }
}


