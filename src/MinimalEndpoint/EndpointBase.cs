using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MinimalEndpoint;

public abstract class EndpointBase
{
    private const string RequireAuthorizationKey = "RequireAuthorization";
    protected EndpointBase()
    {
        actions.Add(RequireAuthorizationKey, b => b.RequireAuthorization());
        if (_tagBuilder is not null)
        {
            actions["WithTags"] = b => b.WithTags(_tagBuilder.Invoke(GetType(), EndpointsNamespace));
        }
    }

    private Dictionary<string, Action<RouteHandlerBuilder>> actions = new Dictionary<string, Action<RouteHandlerBuilder>>();

    protected virtual Action<RouteHandlerBuilder> RouteHandlerBuilder { get; private set; } = (builder) => { };


    public delegate string RouteBuilderDelegate(Type endpointType);

    private static RouteBuilderDelegate? _routeBuilder;

    internal static RouteBuilderDelegate RouteBuilder { set => _routeBuilder = value; }


    public delegate string TagBuilderDelegate(Type endpointType, string endpointsNamespace);

    private static TagBuilderDelegate? _tagBuilder;

    internal static TagBuilderDelegate TagBuilder { set => _tagBuilder = value; }
    internal static string EndpointsNamespace { get; set; } = "Endpoints";

    protected abstract Delegate Handler { get; }

    protected virtual string Pattern =>
     "/"
     + ((_routeBuilder?.Invoke(GetType()) ?? "").Trim('/'))
     + (!string.IsNullOrEmpty(ParametersTemplate) ? "/" + ParametersTemplate.Trim('/') : "");

    protected virtual string ParametersTemplate => "";

    protected abstract EndpointMethod HttpMethod { get; }

    protected virtual RouteHandlerBuilder Map(IEndpointRouteBuilder endpoint)
    {
        var builder = HttpMethod switch
        {
            EndpointMethod.Get => endpoint.MapGet(pattern: Pattern, handler: Handler),
            EndpointMethod.Post => endpoint.MapPost(pattern: Pattern, handler: Handler),
            EndpointMethod.Put => endpoint.MapPut(pattern: Pattern, handler: Handler),
            EndpointMethod.Delete => endpoint.MapDelete(pattern: Pattern, handler: Handler),
            _ => throw new InvalidOperationException($"Invalid http method :{HttpMethod}")
        };

        RouteHandlerBuilder?.Invoke(builder);
        foreach (var (_, action) in actions)
        {
            action.Invoke(builder);
        }
        return builder;
    }

    protected void AllowAnonymous()
    =>
        actions[RequireAuthorizationKey] = (b => b.AllowAnonymous());


    protected void RequireAuthorization()
    =>
        actions[RequireAuthorizationKey] = b => b.RequireAuthorization();


    protected void RequireAuthorization(params string[] policyNames)
    =>
        actions[RequireAuthorizationKey] = b => b.RequireAuthorization(policyNames);


    protected void RequireAuthorization(params IAuthorizeData[] authorizeData)
    =>
        actions[RequireAuthorizationKey] = b => b.RequireAuthorization(authorizeData);


    protected void Produces<TResponse>(
        int statusCode = 200,
        string? contentType = null,
        params string[] additionalContentTypes)
    =>
        Produces(statusCode, typeof(TResponse), contentType, additionalContentTypes);


    protected void Produces(
        int statusCode = 200,
        Type? responseType = null,
        string? contentType = null,
        params string[] additionalContentTypes)
    =>
        actions[$"Produces_{statusCode}"] = b => b.Produces(statusCode, responseType, contentType, additionalContentTypes);

    protected void WithTags(params string[] tags)
    =>
        actions["WithTags"] = b => b.WithTags(tags);


    /* protected void WithDisplayName(string displayName)
     =>
         actions["WithDisplayName"]= b=> b.WithDisplayName(displayName);

     protected void WithGroupName(string endpointGroupName)
     =>
         actions["WithGroupName"]= b=> b.WithGroupName(endpointGroupName);*/


    public void MapEndpoints(IEndpointRouteBuilder endpoint)
    => _ = Map(endpoint);


}
