namespace MinimalEndpoint.Demo.Endpoints.Orders.UpdateOrderDescription;

public class UpdateOrderDescriptionEndpoint : 
EndpointPut<
UpdateOrdeDescriptionRequest, 
IResult, 
IUpdateOrderDescriptionService>
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


