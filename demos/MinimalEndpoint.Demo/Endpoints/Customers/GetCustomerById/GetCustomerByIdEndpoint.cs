namespace MinimalEndpoint.Demo.Endpoints.Customers.GetCustomerById;
public class GetCustomerByIdEndpoint : EndpointGet
{
    protected override Delegate Handler => Handle;

    protected override string Pattern => base.Pattern + "/" + "{customerId:int}";
    private async Task<IResult> Handle(
        HttpContext httpContext,
        int customerId
        )
    {
        await Task.CompletedTask;
        return Results.Ok(new { name = $"Customer Name {customerId}" });
    }
}
