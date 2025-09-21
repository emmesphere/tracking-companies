using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TrackingCompanies.Domain.Interfaces;
using TrackingCompanies.Domain.Repositories;
using TrackingCompanies.Infrastructure.Options;
using TrackingCompanies.Infrastructure.Persistence;
using TrackingCompanies.Infrastructure.Persistence.Data;
using TrackingCompanies.Infrastructure.Persistence.Repositories;

namespace TrackingCompanies.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<ConnectionStringsOptions>(configuration.GetSection("ConnectionStrings"));
        
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var connectionStrings = serviceProvider
                .GetRequiredService<IOptions<ConnectionStringsOptions>>().Value;
            
            options.UseNpgsql(connectionStrings.DefaultConnection, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure();
                npgsqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
            });
        });
            
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
        
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IIndustrySectorRepository, IndustrySectorRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}