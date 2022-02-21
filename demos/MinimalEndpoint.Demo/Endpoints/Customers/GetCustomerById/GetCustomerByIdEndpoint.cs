using Microsoft.AspNetCore.Mvc;

public class GetCustomerByIdEndpoint : EndpointBase, IEndpoint
{
    protected override EndpointMethod HttpMethod => EndpointMethod.Get;
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
