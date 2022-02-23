using System.Diagnostics;

public class HealthCheckEndpoint : EndpointBaseGet, IEndpoint
{    
    protected override Delegate Handler =>
    (IWebHostEnvironment env) =>
    {
        var assembly = typeof(Program).Assembly;
        var lastWriteTime = System.IO.File.GetLastWriteTime(assembly.Location);        
        var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        var name = assembly?.GetName()?.Name?.Replace(".dll", "").Replace(".", " ");
        var environmentName = env.EnvironmentName;
        return Results.Ok($"Name: {name},  Version: {version}, Last Updated: {lastWriteTime}, Server Datetime: {DateTime.UtcNow} EnvironmentName: {environmentName}");
    };

}
