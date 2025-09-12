using EventFlow.Models.Enums.ReportEnums;

namespace EventFlow.Models.Entities.ReportEntity;

public class ReportEntity
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ReporterEmail { get; set; }

    public required ReportParameters Parameters { get; set; }

    public required ReportStatus Status { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? FailedAt { get; set; }
    public string? ErrorMessage { get; set; }
}

public record ReportParameters(
    DateTime StartDate,
    DateTime EndDate,
    ReportFormat Format
);
