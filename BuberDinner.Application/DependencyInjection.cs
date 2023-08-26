using System.Reflection;
using BuberDinner.Application.Common.Behviors;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).GetTypeInfo().Assembly));
        
        // 👇 This is the way to register a generic (such as the type ValidationBehavior) in the dependency injection container
        services.AddScoped(
            typeof(IPipelineBehavior<,>), 
            typeof(ValidationBehavior<,>));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        // ℹ️ AddValidatorsFromAssembly(): This is an extension method provided by some
        // validation libraries, such as FluentValidation. It scans an assembly
        // (in this case, the executing assembly, which is the assembly where
        // this code is being called from) for classes that implement validation rules.
        // It then registers those validator classes in the dependency injection container
        
        return services;
    }
}