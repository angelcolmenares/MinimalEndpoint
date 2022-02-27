namespace MinimalEndpoint;

public abstract class EndpointDeleteWith<TRequest, TResponse, TService> :
EndpointBase<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Delete;
}
