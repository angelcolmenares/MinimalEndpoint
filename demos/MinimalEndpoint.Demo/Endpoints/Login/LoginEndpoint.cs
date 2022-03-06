using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MinimalEndpoint.Demo.Endpoints.Login;

public class LoginEndpoint : EndpointPost
{
    public LoginEndpoint()
    =>
        AllowAnonymous();

    protected override Delegate Handler => Handle;

    private async Task<IResult> Handle(
        HttpContext httpContext,
        LoginRequest request)
    {
        var userName = request.UserName ?? "anonymous";
        var isAdmin = userName.ToLower()=="admin" || userName.ToLower().Contains("admin") ;
        var claims = new List<Claim>
        {
            new Claim( ClaimTypes.Name, userName),
            new Claim( ClaimTypes.Role, ( isAdmin?"admin": "user")),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);


        await httpContext.SignInAsync(
           CookieAuthenticationDefaults.AuthenticationScheme,
           new ClaimsPrincipal(claimsIdentity));

        return Results.Ok();
    }

}
