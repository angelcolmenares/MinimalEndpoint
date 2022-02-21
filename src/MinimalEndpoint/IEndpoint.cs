
using Microsoft.AspNetCore.Routing;

namespace MinimalEndpoint
{
    public interface IEndpoint
    {
        void MapEndpoints(IEndpointRouteBuilder endpoint);
    }
}