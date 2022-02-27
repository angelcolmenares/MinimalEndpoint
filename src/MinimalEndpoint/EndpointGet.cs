namespace MinimalEndpoint
{
    public abstract class EndpointGet:EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Get;
    }
}