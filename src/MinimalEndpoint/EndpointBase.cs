using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace MinimalEndpoint
{
    public abstract class EndpointBase
    {
        static Regex r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])",
                     RegexOptions.IgnorePatternWhitespace);

        public delegate string RouteBuilderDelegate(Type endpointType);

        private static RouteBuilderDelegate? _routeBuilder;

        internal static RouteBuilderDelegate RouteBuilder { set => _routeBuilder = value; }
        protected abstract Delegate Handler { get; }

        protected virtual string Pattern =>
         "/" + _routeBuilder?.Invoke(GetType()) ?? "";

        protected abstract EndpointMethod HttpMethod { get; }

        protected virtual RouteHandlerBuilder Map(IEndpointRouteBuilder endpoint)
        =>
            HttpMethod switch
            {
                EndpointMethod.Get => endpoint.MapGet(pattern: Pattern, handler: Handler),
                EndpointMethod.Post => endpoint.MapPost(pattern: Pattern, handler: Handler),
                EndpointMethod.Put => endpoint.MapPut(pattern: Pattern, handler: Handler),
                EndpointMethod.Delete => endpoint.MapDelete(pattern: Pattern, handler: Handler),
                _ => throw new InvalidOperationException($"Invalid http method :{HttpMethod}")
            };

        public void MapEndpoints(IEndpointRouteBuilder endpoint)
        => _ = Map(endpoint);

    }
}