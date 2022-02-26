namespace MinimalEndpoint
{
    public abstract class EndpointBasePostWith<TResponse> : EndpointBase<TResponse>
    {
        protected override abstract RequestDelegate RequestHandler {get;}

        protected override EndpointMethod HttpMethod => EndpointMethod.Post;
    }

    public abstract class EndpointBasePostWith<TRequest,TResponse> :
     EndpointBase<TRequest, TResponse>
    {
        protected override abstract RequestDelegate RequestHandler {get;}

        protected override EndpointMethod HttpMethod => EndpointMethod.Post;
    }
}