public class CreateCustomerEndPoint : EndpointBasePost, IEndpoint
{
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

    protected override Action<RouteHandlerBuilder> RouteHandlerBuilder
    => Configure;

    private void Configure(RouteHandlerBuilder builder) => builder.Produces<CreateCustomerResponse>();
}
