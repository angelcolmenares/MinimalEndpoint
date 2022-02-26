namespace MinimalEndpoint.Demo.Endpoints.Orders.UpdateOrderDescription;

public class UpdateOrdeDescriptionRequest
{

    // string for the sake of simplicity
    public string Id { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

}
