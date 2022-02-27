namespace MinimalEndpoint.Demo.Endpoints.Login;

public class AccessDeniedEndpoint : EndpointGet, IEndpoint
{
    protected override Delegate Handler => () => "Access Denied";
}
