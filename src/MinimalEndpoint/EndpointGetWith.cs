namespace MinimalEndpoint;

///
/// <summary>
/// Caution !!! no binding suppor for complex TRequest classes !!!!
/// </summary>
public abstract class EndpointGet<TRequest, TResponse, TService> :
Endpoint<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Get;
}
