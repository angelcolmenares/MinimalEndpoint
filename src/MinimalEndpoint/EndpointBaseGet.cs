namespace MinimalEndpoint
{
    public abstract class EndpointBaseGet:EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Get;
    }
}