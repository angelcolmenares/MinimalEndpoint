public class GetCustomerByIdEndpoint : EndpointBaseGet, IEndpoint
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
