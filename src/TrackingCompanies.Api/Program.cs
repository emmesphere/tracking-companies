using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Api.Endpoints;
using TrackingCompanies.Api.Extensions;
using TrackingCompanies.Application;
using TrackingCompanies.Domain.Interfaces;
using TrackingCompanies.Infrastructure;
using TrackingCompanies.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseStatusCodePages();

app.MapCompaniesEndpoints();
app.MapGet("/health", () => Results.Ok(new { status = "Healthy", timestamp = DateTime.UtcNow }));

using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync();
        
        var seeder = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
        await seeder.SeedAsync();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database");
    }
}

app.Run();