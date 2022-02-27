namespace MinimalEndpoint;

public abstract class EndpointDeleteWith<TRequest, TResponse, TService> :
EndpointWith<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Delete;
}
