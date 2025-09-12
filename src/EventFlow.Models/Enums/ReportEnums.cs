
namespace EventFlow.Models.Enums.ReportEnums;

public enum ReportStatus
{
    Reported,
    Validated,
    Aggregated,
    Rendered,
    Completed,
    Failed
}

public enum ReportFormat
{
    pdf,
    excel, 
    csv
}