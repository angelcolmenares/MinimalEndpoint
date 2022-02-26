namespace MinimalEndpoint.Demo.Endpoints.Login;

public class AccessDeniedEndpoint : EndpointBaseGet, IEndpoint
{
    protected override Delegate Handler => () => "Access Denied";
}
