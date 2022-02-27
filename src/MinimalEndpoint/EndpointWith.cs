using Microsoft.AspNetCore.Http;

namespace MinimalEndpoint;

public abstract class EndpointWith<TRequest, TResponse, TService> : EndpointBase
{
    protected EndpointWith()
    {
        if (typeof(TResponse) != typeof(IResult))
        {
            Produces<TResponse>();
        }
    }
    public delegate Task<TResponse> RequestDelegate(
        TRequest request,
        HttpContext httpContext,
        TService service,
        CancellationToken cancellationToken=default);

    protected abstract RequestDelegate RequestHandler { get; }

    protected override Delegate Handler => RequestHandler;

    protected override abstract EndpointMethod HttpMethod { get; }
}
