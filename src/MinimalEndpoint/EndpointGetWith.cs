namespace MinimalEndpoint;

///
/// <summary>
/// Caution !!! no binding suppor for complex TRequest classes !!!!
/// </summary>
public abstract class EndpointGetWith<TRequest, TResponse, TService> :
EndpointWith<TRequest, TResponse, TService>
{
    protected override abstract RequestDelegate RequestHandler { get; }

    protected override EndpointMethod HttpMethod => EndpointMethod.Get;
}
