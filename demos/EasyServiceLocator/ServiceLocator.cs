namespace EasyServiceLocator;

public static class ServiceLocator
{
    private static  IServiceProvider? _serviceProvider;
    public static IServiceProvider ServiceProvider 
    => 
    _serviceProvider?? throw new ArgumentNullException("You should Initialize the ServiceProvider");

    public static void Initialize(IServiceProvider serviceProvider)
    => _serviceProvider =serviceProvider;
    
}
