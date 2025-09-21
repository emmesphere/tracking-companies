using TrackingCompanies.Infrastructure.Persistence;

namespace TrackingCompanies.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddHealthChecks();
            
        return services;
    }
}