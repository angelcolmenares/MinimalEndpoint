namespace MinimalEndpoint;

public abstract class EndpointPut<TRequest, TResponse, TService> :
Endpoint<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Put;
}
