public class UpdateCustomerNameEndpoint : EndpointBase, IEndpoint
{
    protected override EndpointMethod HttpMethod => EndpointMethod.Put;
    protected override string Pattern => base.Pattern + "/" + "{customerId:int}";
    protected override Delegate Handler => Handle;

    private async Task<IResult> Handle(
        HttpContext httpContext,
        int customerId,
        UpdateCustomerNameRequest request )
    {
        await Task.CompletedTask;
        return Results.Ok( new { request.CusomterId, request.Name});
    }

}
