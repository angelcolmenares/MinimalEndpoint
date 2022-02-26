namespace MinimalEndpoint.Demo.Endpoints.Admin;

public class AdminEndpoint : EndpointBaseGet, IEndpoint
{
    public AdminEndpoint()=> RequireAuthorization("AdminsOnly");
    protected override Delegate Handler => 
    (HttpContext httpContext )=>
    {
        var identity = httpContext?.User?.Identity;
        if (identity == default)
        {
            return Results.BadRequest("no login?");
        }

        var name = identity.Name ?? string.Empty;
        
        return Results.Ok($"welcome {name} you have admin permissions");
    };


}
