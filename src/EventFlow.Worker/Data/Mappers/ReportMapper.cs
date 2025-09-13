
using EventFlow.Models.Dtos; 
using EventFlow.Models.Enums.ReportEnums;
using EventFlow.Models.Entities.ReportEntity;

namespace EventFlow.Worker.Data.Mappers.ReportMapper;

public class ReportMapper
{ 
    public ReportDto ToDto(ReportEntity entity)
    {
        return new ReportDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            ReporterEmail = entity.ReporterEmail,
            Status = entity.Status,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            CompletedAt = entity.CompletedAt,
            FailedAt = entity.FailedAt,
            ErrorMessage = entity.ErrorMessage,
            Parameters = entity.Parameters
        };
    }

    public ReportEntity ToEntity(ReportDto dto)
    {
        return new ReportEntity
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            ReporterEmail = dto.ReporterEmail,
            Status = dto.Status,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
            CompletedAt = dto.CompletedAt,
            FailedAt = dto.FailedAt,
            ErrorMessage = dto.ErrorMessage,
            Parameters = dto.Parameters
        };
    }

}