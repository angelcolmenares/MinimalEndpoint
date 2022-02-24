namespace MinimalEndpoint
{
    public abstract class EndpointBasePost: EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Post;
    }
}