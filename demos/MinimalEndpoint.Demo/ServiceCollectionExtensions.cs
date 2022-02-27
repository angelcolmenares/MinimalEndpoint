using MinimalEndpoint.Demo.Endpoints.Orders.CreateOrder;
using MinimalEndpoint.Demo.Endpoints.Orders.DeleteOrder;
using MinimalEndpoint.Demo.Endpoints.Orders.GetOrderById;
using MinimalEndpoint.Demo.Endpoints.Orders.UpdateOrderDescription;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersServices(this IServiceCollection services)
    {
        services.AddTransient<ICreateOrderService, CreateOrderService>();
        services.AddTransient<IUpdateOrderDescriptionService, UpdateOrderDescriptionService>();
        services.AddTransient<IDeleteOrderService, DeleteOrderService>();
        services.AddTransient<IGetOrderByIdService, GetOrderByIdService>();
        return services;
    }
}
