namespace MinimalEndpoint
{
    public abstract class EndpointBasePut: EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Put;
    }
}