namespace MinimalEndpoint.Demo.Endpoints.Orders.GetOrderById;

public interface IGetOrderByIdService
{
    Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken = default);
}
