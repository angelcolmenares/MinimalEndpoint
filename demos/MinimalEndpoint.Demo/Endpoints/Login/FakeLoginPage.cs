namespace MinimalEndpoint.Demo.Endpoints.Login;

public class FakeLoginPage : EndpointBaseGet, IEndpoint
{
    public FakeLoginPage()
    { 
        AllowAnonymous(); 

    }

    protected override Delegate Handler =>
        () => "please login from swagger";
}
