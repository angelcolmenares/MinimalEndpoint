namespace MinimalEndpoint.Demo.Endpoints.Customers.UpdateCustomerName;
public class UpdateCustomerNameEndpoint : EndpointBasePut, IEndpoint
{    
    protected override string ParametersTemplate => "{customerId:int}";
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
