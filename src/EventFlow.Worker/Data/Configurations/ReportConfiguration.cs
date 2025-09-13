
using Microsoft.EntityFrameworkCore;
using EventFlow.Models.Entities.ReportEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFlow.Worker.Data.Configurations;

public class ReportEntityConfiguration : IEntityTypeConfiguration<ReportEntity>
{
    public void Configure(EntityTypeBuilder<ReportEntity> builder)
    {
        builder.ToTable("Reports");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(r => r.Description)
            .IsRequired();

        builder.Property(r => r.ReporterEmail)
            .IsRequired();

        builder.Property(r => r.Parameters)
            .IsRequired();

        builder.Property(r => r.Parameters.StartDate)
            .IsRequired();
            
        builder.Property(r => r.Status)
            .IsRequired();

        builder.Property(r => r.CreatedAt);

        builder.Property(r => r.UpdatedAt);

        builder.Property(r => r.CompletedAt);


        builder.Property(r => r.FailedAt);

        builder.Property(r => r.ErrorMessage);


    }
}