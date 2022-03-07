using EasyServiceLocator;
using MinimalEndpoint.Demo.Data;

namespace MinimalEndpoint.Demo.Endpoints.Orders;

public abstract class OrdersCommandService<TRequest, TResponse>
{
    protected OrdersDbContext OrdersDbContext {get; private set;}

    protected OrdersCommandService()
    {
        var sp = ServiceLocator.ServiceProvider;
        
        OrdersDbContext=sp?.GetService<OrdersDbContext>() ?? 
        throw new ArgumentNullException("");
        
    }

    protected abstract Task<TResponse> Execute(TRequest request,
        CancellationToken cancellationToken = default);

    public async Task<TResponse> Handle(TRequest request,
        CancellationToken cancellationToken = default)
    {
        var result =  await Execute(request, cancellationToken);
        await OrdersDbContext.SaveChangesAsync(cancellationToken);
        return result;
    }
}
