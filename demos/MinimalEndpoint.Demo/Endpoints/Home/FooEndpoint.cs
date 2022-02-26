namespace MinimalEndpoint.Demo.Endpoints.Home;

public class FooEndpoint : EndpointBaseGet, IEndpoint
{
    public FooEndpoint() => AllowAnonymous();
    protected override Delegate Handler =>
    (string name) =>
    {
        return name;
    };
}


