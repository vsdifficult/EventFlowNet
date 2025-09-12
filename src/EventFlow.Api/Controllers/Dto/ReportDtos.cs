using EventFlow.Models.Enums.ReportEnums;
using EventFlow.Models.Entities.ReportEntity; 

namespace EventFlow.Api.Controllers.Dtos;

public record ReportDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string ReporterEmail { get; init; }
    public ReportStatus Status { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public DateTime? CompletedAt { get; init; }
    public DateTime? FailedAt { get; init; }
    public string? ErrorMessage { get; init; }
    public ReportParameters Parameters { get; init; }
}

public record CreateReportDto
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string ReporterEmail { get; init; }
    public ReportParameters Parameters { get; init; }
} 