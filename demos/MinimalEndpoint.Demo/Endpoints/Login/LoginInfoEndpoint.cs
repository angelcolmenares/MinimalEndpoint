using System.Security.Claims;

namespace MinimalEndpoint.Demo.Endpoints.Login;

public class LoginInfoEndpoint : EndpointBaseGet, IEndpoint
{
    public LoginInfoEndpoint()
    {
        Produces<LoginInfoResponse>();
    }

    protected override Delegate Handler =>  (HttpContext httpContext) =>
    {
        var identity = httpContext?.User?.Identity;
        if (identity == default)
        {
            return Results.BadRequest("no login?");
        }

        var name = identity.Name ?? string.Empty;
        var role = httpContext?.User.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Role)?.Value ?? string.Empty;
        
        return Results.Ok(new LoginInfoResponse
        {
            UserName = name,
            Role = role,
        });
    };
}
