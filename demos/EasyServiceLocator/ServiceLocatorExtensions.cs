using EasyServiceLocator;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceLocatorExtensions
{
    
    public static IServiceCollection AddServiceLocator(this IServiceCollection services)
    {
        
        ServiceLocator.Initialize(services.BuildServiceProvider() );
        return services;
    }
}
