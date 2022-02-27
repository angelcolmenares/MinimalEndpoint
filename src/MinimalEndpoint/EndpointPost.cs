namespace MinimalEndpoint
{
    public abstract class EndpointPost: EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Post;
    }
}