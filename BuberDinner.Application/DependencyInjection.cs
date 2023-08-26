using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).GetTypeInfo().Assembly));
        
        return services;
    }
}