using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.Interfaces;

namespace TrackingCompanies.Infrastructure.Persistence.Data;

public class DatabaseSeeder : IDatabaseSeeder
{
    private readonly AppDbContext _context;

    public DatabaseSeeder(AppDbContext context)
    {
        _context = context;
    }
    public async Task SeedAsync()
    {
        await SeedIndustrySectorsAsync();
        await SeedCompaniesAsync();
        await _context.SaveChangesAsync();
    }
    
    private async Task SeedIndustrySectorsAsync()
    {
        if (await _context.IndustrySectors.AnyAsync())
            return;

        var sectors = new[]
        {
            IndustrySector.CreateIndustrySector(1, "Food and Beverage", "Food and Beverage" ),
            IndustrySector.CreateIndustrySector(2, "Aviation", "Flight company"),
            IndustrySector.CreateIndustrySector(3, "Finance", "Finance"),
            IndustrySector.CreateIndustrySector(4, "Stock Exchange","Stock Exchange"),
            IndustrySector.CreateIndustrySector(5, "Construction", "Construction" ),
            IndustrySector.CreateIndustrySector(6, "Education", "Education"),
            IndustrySector.CreateIndustrySector(7, "Finance", "Finance"),
            IndustrySector.CreateIndustrySector(8, "Energy","Energy"),
            IndustrySector.CreateIndustrySector(9, "Pharmaceutical", "Pharmacy, Chemistry, Drugstore" ),
            IndustrySector.CreateIndustrySector(10, "Railway", "Train company"),
            IndustrySector.CreateIndustrySector(11, "Real State", "Real State"),
            IndustrySector.CreateIndustrySector(12, "Car Renting","Car renting"),
            IndustrySector.CreateIndustrySector(13, "Wood and Beverage", "Food and Beverage" ),
            IndustrySector.CreateIndustrySector(14, "Wood and Cellulose", "Wood and Cellulose"),
            IndustrySector.CreateIndustrySector(15, "Mining", "Mining"),
            IndustrySector.CreateIndustrySector(16, "Petroil","Petroil"),
            IndustrySector.CreateIndustrySector(17, "Road and Highway", "Road" ),
            IndustrySector.CreateIndustrySector(18, "Sanitation", "Sanitation"),
            IndustrySector.CreateIndustrySector(19, "Health care", "Health care"),
            IndustrySector.CreateIndustrySector(20, "Insurance","Insurance"),
            IndustrySector.CreateIndustrySector(21, "Animal health care", "Pet shop" ),
            IndustrySector.CreateIndustrySector(22, "Steel industry", "Steel mill"),
            IndustrySector.CreateIndustrySector(23, "Telecommunications", "Telecom"),
            IndustrySector.CreateIndustrySector(24, "Technology","Technology"),
            IndustrySector.CreateIndustrySector(25, "Retail", "Retail" ),
            IndustrySector.CreateIndustrySector(26, "Tourism", "Tourism"),
            IndustrySector.CreateIndustrySector(27, "Motor", "Motor" ) 
        };

        await _context.IndustrySectors.AddRangeAsync(sectors);
    }

    private async Task SeedCompaniesAsync()
    {
        if (await _context.Companies.AnyAsync())
            return;

        var companies = new[]
        {
            Company.CreateNew("Banco do Brasil", "BBAS3", 7),
            Company.CreateNew("Petrobrás", "PETR3", 16),
            Company.CreateNew("Itaú S.A", "ITSA3", 7),
            Company.CreateNew("Bradesco", "BBDC3", 7)
        };

        await _context.Companies.AddRangeAsync(companies);
    }
}