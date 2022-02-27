namespace MinimalEndpoint;

public abstract class EndpointDelete<TRequest, TResponse, TService> :
Endpoint<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Delete;
}
