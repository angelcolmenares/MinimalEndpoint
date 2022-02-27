namespace MinimalEndpoint.Demo.Endpoints.Login;

public class FakeLoginPage : EndpointGet, IEndpoint
{
    public FakeLoginPage()
    { 
        AllowAnonymous(); 

    }

    protected override Delegate Handler =>
        () => "please login from swagger";
}
