namespace MinimalEndpoint;

public abstract class EndpointPostWith<TRequest, TResponse, TService> :
EndpointWith<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Post;
}
