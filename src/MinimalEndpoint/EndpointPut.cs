namespace MinimalEndpoint
{
    public abstract class EndpointPut: EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Put;
    }
}