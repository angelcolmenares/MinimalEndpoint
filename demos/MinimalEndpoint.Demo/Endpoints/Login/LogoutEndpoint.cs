using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MinimalEndpoint.Demo.Endpoints.Login;

public class LogoutEndpoint : EndpointPost
{
    protected override Delegate Handler =>
    async (HttpContext httpContext) => 
    await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}
