namespace MinimalEndpoint
{
    public abstract class EndpointBaseDelete:EndpointBase
    {
        protected override EndpointMethod HttpMethod => EndpointMethod.Delete;
    }
}