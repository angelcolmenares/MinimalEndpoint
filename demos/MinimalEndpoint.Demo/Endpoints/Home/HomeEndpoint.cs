public class HomeEndpoint : EndpointBaseGet, IEndpoint
{
    public HomeEndpoint()=> AllowAnonymous();
    protected override string Pattern => "/";
    protected override Delegate Handler =>
    () => "Hello world";

}