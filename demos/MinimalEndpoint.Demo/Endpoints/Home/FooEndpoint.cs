using Microsoft.AspNetCore.Mvc;

namespace MinimalEndpoint.Demo.Endpoints.Home;

public class FooEndpoint : EndpointGet
{
    public FooEndpoint() => AllowAnonymous();
    protected override Delegate Handler =>
    (string name) =>
    {
        return name;
    };
}

public 
class FooRequest
{
    [FromQuery] public string Name {get;set;}= string.Empty;
}