using Microsoft.EntityFrameworkCore;
using EventFlow.Models.Entities.ReportEntity;
using EventFlow.Worker.Data.Configurations; 

namespace EventFlow.Worker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ReportEntity> Reports { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("reports");
        modelBuilder.ApplyConfiguration(new ReportEntityConfiguration()); 
    } 
}