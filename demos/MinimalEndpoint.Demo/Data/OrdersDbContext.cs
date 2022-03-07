namespace MinimalEndpoint.Demo.Data;

public class OrdersDbContext
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        Console.WriteLine ("Saving ...");
        return await Task.FromResult(1);
    }
}
