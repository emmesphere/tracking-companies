using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.ValueObject;

namespace TrackingCompanies.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<IndustrySector> IndustrySectors => Set<IndustrySector>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(c => c.Id);
            
            entity.OwnsOne(c => c.Ticker, ticker =>
            {
                ticker.Property(t => t.Code)
                    .HasColumnName("Ticker")
                    .HasMaxLength(10)
                    .IsRequired();
                
                ticker.HasIndex(t => t.Code).IsUnique();
            });
            
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);
                
            entity.Property(c => c.IndustrySectorId)
                .IsRequired();
                
            entity.HasOne(c => c.IndustrySector)
                .WithMany()
                .HasForeignKey(c => c.IndustrySectorId);
        });
        base.OnModelCreating(modelBuilder);
    }
}