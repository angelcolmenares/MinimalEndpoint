namespace MinimalEndpoint.Demo.Endpoints.Customers.CreateCustomer
{
    public class CreateCustomerEndPoint : EndpointBase, IEndpoint
    {

        protected override EndpointMethod HttpMethod => EndpointMethod.Post;
        protected override Delegate Handler => Handle;

        protected override RouteHandlerBuilder Map(IEndpointRouteBuilder endpoint)
        {
            return base.Map(endpoint).Produces<CreateCustomerResponse>();
        }

        private async Task<IResult> Handle(
            HttpContext httpContext,
            CreateCustomerRequest request)
        {
            await Task.CompletedTask;
            return Results.Ok(
               new CreateCustomerResponse
               {
                   CustomerId = 1000
               });
        }
    }
}