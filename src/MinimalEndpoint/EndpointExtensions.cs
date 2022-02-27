using System.Reflection;
using Microsoft.AspNetCore.Builder;
using static MinimalEndpoint.EndpointBase;

namespace MinimalEndpoint;

public static class EndpointExtensions
{

    public static WebApplication MapEndpointsFromCurrentAssembly(
        this WebApplication app,
        string? patternPrefix = null,
        RouteBuilderDelegate? routeBuilderDelegate = null)
    {
        var assembly = Assembly.GetCallingAssembly();
        return MapEndpointsFromAssembly(app, assembly, patternPrefix, routeBuilderDelegate);
    }

    public static WebApplication MapEndpointsFromAssembly(
        this WebApplication app,
        Assembly assembly,
        string? patternPrefix = null,
        RouteBuilderDelegate? routeBuilderDelegate = null,
        string endpointsNamespace = "Endpoints",
        TagBuilderDelegate? tagBuilderDelegate = null)
    {
        var normalizedPatternPrefix =
        (!string.IsNullOrEmpty(patternPrefix) ? patternPrefix : "")
        .Trim('/');

        EndpointBase.RouteBuilder = (t)
        =>
        normalizedPatternPrefix + "/" + (routeBuilderDelegate ?? DefaultRouteBuilder.Build).Invoke(t);

        EndpointBase.EndpointsNamespace = endpointsNamespace;

        EndpointBase.TagBuilder = (t, ns)
        => (tagBuilderDelegate ?? DefaultTagBuilder.Build).Invoke(t, ns);


        var modules = DiscoverEndpoints(assembly);

        foreach (var module in modules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }

    private static IEnumerable<IEndpoint> DiscoverEndpoints(Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(p => p.IsClass && !p.IsAbstract && p.IsAssignableTo(typeof(IEndpoint)))
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>();
    }
}
