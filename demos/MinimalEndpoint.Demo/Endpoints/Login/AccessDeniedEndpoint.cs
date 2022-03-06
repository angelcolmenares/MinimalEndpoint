namespace MinimalEndpoint.Demo.Endpoints.Login;

public class AccessDeniedEndpoint : EndpointGet
{
    protected override Delegate Handler => () => "Access Denied";
}
