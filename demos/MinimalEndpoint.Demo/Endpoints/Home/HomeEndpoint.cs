public class HomeEndpoint : EndpointBaseGet, IEndpoint
{
    protected override string Pattern => "/";
    protected override Delegate Handler =>
    () => "Hello world";

}