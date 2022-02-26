namespace MinimalEndpoint.Demo.Endpoints.Customers.CreateCustomer;
public class CreateCustomerEndpoint : EndpointBasePost, IEndpoint
{
    public CreateCustomerEndpoint()=> Produces<CreateCustomerResponse>();
    
    protected override Delegate Handler => Handle;

    private async Task<IResult> Handle(
        HttpContext httpContext,
        CreateCustomerRequest request)
    =>
        await Task.FromResult(
            Results.Ok(
                new CreateCustomerResponse
                {
                    CustomerId = 1000
                }
            )
        );

}
