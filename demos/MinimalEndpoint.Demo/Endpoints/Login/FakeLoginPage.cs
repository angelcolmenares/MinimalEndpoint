namespace MinimalEndpoint.Demo.Endpoints.Login;

public class FakeLoginPage : EndpointGet
{
    public FakeLoginPage()
    { 
        AllowAnonymous(); 

    }

    protected override Delegate Handler =>
        () => "please login from swagger";
}
