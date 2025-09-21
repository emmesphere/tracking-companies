using Microsoft.Extensions.DependencyInjection;
using TrackingCompanies.Application.Commands;
using TrackingCompanies.Application.Commands.Handlers;
using TrackingCompanies.Application.Dispatcher;

namespace TrackingCompanies.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher.Implementation.Dispatcher>();
        services.AddScoped<ICommandHandler<CreateCompanyCommand, Guid>, CreateCompanyCommandHandler>();
        
        
        // services.Scan(scan => scan
        //     .FromAssembliesOf(typeof(DependencyInjection))
        //     .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());
        //     
        // services.Scan(scan => scan
        //     .FromAssembliesOf(typeof(DependencyInjection))
        //     .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());
        //
        // services.Scan(scan => scan
        //     .FromAssembliesOf(typeof(DependencyInjection))
        //     .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());
        
        return services;
    } 
}