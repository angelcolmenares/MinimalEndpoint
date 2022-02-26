public class CreateCustomerEndPoint : EndpointBasePost, IEndpoint
{
    public CreateCustomerEndPoint()=> Produces<CreateCustomerResponse>();
    
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
