namespace MinimalEndpoint;

public abstract class EndpointBase<TResponse> : EndpointBase
{
    protected EndpointBase()=> Produces<TResponse>();
    public delegate Task<TResponse> RequestDelegate(params object[] request);
    
    protected abstract RequestDelegate RequestHandler {get;}
    
    protected override Delegate Handler => RequestHandler;

    protected override abstract EndpointMethod HttpMethod { get; }
}

public abstract class EndpointBase<TRequest, TResponse> : EndpointBase
{
    protected EndpointBase()=> Produces<TResponse>();
    public delegate Task<TResponse> RequestDelegate(TRequest request, params object[] args);
    
    protected abstract RequestDelegate RequestHandler {get;}
    
    protected override  Delegate Handler => RequestHandler;

    protected override abstract EndpointMethod HttpMethod { get; }
}
