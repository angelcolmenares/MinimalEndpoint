namespace MinimalEndpoint;

public interface IServiceBehavior<TService>
{
    Task ExecuteBefore<TRequest>(TRequest request);
Task ExecuteAfter<TRequest,TResponse>(TRequest request, TResponse response) ;
}
