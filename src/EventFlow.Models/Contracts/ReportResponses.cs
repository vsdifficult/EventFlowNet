

namespace EventFlow.Models.Contracts.ReportResponses; 

public record ReportRequested(
    Guid ReportId,
    string Title,
    string RequesterEmail,
    DateTime StartDate,
    DateTime EndDate,
    string Format
);

public record ReportCompleted(
    Guid ReportId,
    string FileUrl,
    DateTime CompletedAt
);

public record ReportFailed(
    Guid ReportId,
    string ErrorMessage,
    DateTime FailedAt
); 
