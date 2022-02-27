namespace MinimalEndpoint;

public abstract class EndpointPutWith<TRequest, TResponse, TService> :
EndpointWith<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Put;
}
