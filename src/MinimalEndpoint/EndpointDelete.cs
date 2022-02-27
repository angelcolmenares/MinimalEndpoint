namespace MinimalEndpoint;

public abstract class EndpointDelete : EndpointBase
{
    protected override EndpointMethod HttpMethod => EndpointMethod.Delete;
}
