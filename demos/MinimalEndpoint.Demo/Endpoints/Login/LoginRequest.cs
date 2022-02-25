namespace MinimalEndpoint.Demo.Endpoints.Login
{
    public class LoginRequest
    {
        public string UserName {get; init;} =string.Empty;
        public string Password {get; init;} = string.Empty;
    }
}