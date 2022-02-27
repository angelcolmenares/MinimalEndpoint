namespace MinimalEndpoint.Demo.Endpoints.Orders.GetOrderById;

public class GetOrderByIdService : IGetOrderByIdService
{
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken = default)
    {


        return await Task.FromResult(
            new GetOrderByIdResponse
            {
                Description = $"Oder description for order id: {request.Id}"
            });
    }
}