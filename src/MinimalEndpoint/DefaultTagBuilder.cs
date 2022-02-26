namespace MinimalEndpoint;

public static class DefaultTagBuilder
{
    public static string Build(Type type, string endpointsNamespace)
    {
        var parts = type?.Namespace?.Split(".")?.ToList() ?? new List<string>();

        var index = parts.LastIndexOf(endpointsNamespace);

        return (index < 0) ? endpointsNamespace : parts[index + 1];

    }
}
