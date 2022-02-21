using System.Reflection;
using Microsoft.AspNetCore.Builder;
using static MinimalEndpoint.EndpointBase;

namespace MinimalEndpoint
{
    public static class EndpointExtensions
    {

        public static WebApplication MapEndpointsFromCurrentAssembly(
            this WebApplication app,
            RouteBuilderDelegate? routeBuilderDelegate = null)
        {
            var assembly = Assembly.GetCallingAssembly();
            return MapEndpointsFromAssembly(app, assembly, routeBuilderDelegate);
        }

        public static WebApplication MapEndpointsFromAssembly(
            this WebApplication app,
            Assembly assembly,
            RouteBuilderDelegate? routeBuilderDelegate = null)
        {
            EndpointBase.RouteBuilder = routeBuilderDelegate ?? DefaultRouteBuilder.Build;
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
}