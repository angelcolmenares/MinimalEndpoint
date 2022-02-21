public class HomeEndpoint : EndpointBase, IEndpoint
{
    protected override EndpointMethod HttpMethod => EndpointMethod.Get;
    protected override string Pattern => "/";
    protected override Delegate Handler =>
    () => "Hello world";

}