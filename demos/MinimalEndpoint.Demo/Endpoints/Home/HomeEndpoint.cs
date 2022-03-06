namespace MinimalEndpoint.Demo.Endpoints.Home;
public class HomeEndpoint : EndpointGet
{
    public HomeEndpoint()=> AllowAnonymous();
    protected override string Pattern => "/";
    protected override Delegate Handler =>
    () => "Hello world";

}