using ControleFinanceiro.Infrastructure.Shared.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infrastructure.Shared;

public static class IoCContainer
{
    public static IServiceCollection AutoInjectAll(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var ass  in assemblies)
        {
            var types = ass.GetTypes().Where(
                type =>
                    type is { IsAbstract: false, IsInterface: false } &&
                    type.GetInterfaces().Any(@interface =>  
                        @interface == typeof(IScopedService) ||
                        @interface == typeof(ITransientService) ||
                        @interface == typeof(ISingletonService)
                    ));

            foreach (var type in types)
            {
                var abstractions = type.GetInterfaces();

                foreach (var abstraction in abstractions)
                {
                    if (typeof(IScopedService).IsAssignableFrom(type))
                    {
                        if (services.All(service => service.ServiceType != type))
                            services.AddScoped(type);
                        
                        services.AddScoped(abstraction, resolver => 
                            resolver.GetService(type) ?? throw new InvalidOperationException());
                    }
                    else if (typeof(ITransientService).IsAssignableFrom(type))
                    {
                        if(services.All(service => service.ServiceType != type))
                            services.AddTransient(type);


                        services.AddTransient(abstraction, type);
                    }
                    else if(typeof(ISingletonService).IsAssignableFrom(type))
                    {
                        if (services.All(service => service.ServiceType != type))
                            services.AddSingleton(abstraction, type);

                        services.AddSingleton(abstraction, resolver => 
                            resolver.GetService(type) ?? throw new InvalidOperationException());

                    }
                }
            }
        }
        return services;
    }
}