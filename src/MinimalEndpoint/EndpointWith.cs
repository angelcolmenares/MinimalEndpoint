using Microsoft.AspNetCore.Http;

namespace MinimalEndpoint;

public abstract class Endpoint<TRequest, TResponse, TService> : EndpointBase
{
    protected Endpoint()
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

    protected override RequestDelegate FinalRequestHandler =>async (
        TRequest request,
        HttpContext httpContext,
        TService services,
        CancellationToken cancellationToken)=>
        {
            IServiceBehavior<TService>? c = (IServiceBehavior<TService>?) httpContext
            .RequestServices
            .GetService(typeof(IServiceBehavior<TService>));
            if( c is not null)
            {
                await c.ExecuteBefore(request);
            }

            var response= await RequestHandler.Invoke(request, httpContext, services, cancellationToken);

            if( c is not null)
            {
                await c.ExecuteAfter(request,response);
            }
            return response;
        };
}
