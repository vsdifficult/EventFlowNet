using Microsoft.EntityFrameworkCore;
using EventFlow.Models.Dtos;
using EventFlow.Models.Enums.ReportEnums;
using EventFlow.Models.Entities.ReportEntity;
using EventFlow.Worker.Data.Mappers.ReportMapper; 

namespace EventFlow.Worker.Data.Repositories;

public class ReportRepository
{
    private readonly AppDbContext _dbcontext;
    private readonly ReportMapper _mapper;

    public ReportRepository(AppDbContext dbcontext, ReportMapper mapper)
    {
        _dbcontext = dbcontext;
        _mapper = mapper;
    }

    public async Task<Guid> CreateAsync(CreateReportDto dto)
    {
        var entity = new ReportEntity
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            ReporterEmail = dto.ReporterEmail,
            Status = ReportStatus.Reported,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            FailedAt = null,
            CompletedAt = null,
            ErrorMessage = null,
            Parameters = dto.Parameters
        };

        await _dbcontext.Reports.AddAsync(entity);
        await _dbcontext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<ReportDto> GetAsync(Guid id)
    {
        var entity = await _dbcontext.Reports.FirstOrDefaultAsync(e => e.Id == id);
        return _mapper.ToDto(entity) ?? null;
    }

    public async Task<List<ReportDto>> GetAllAsync()
    {
        var entities = await _dbcontext.Reports.ToListAsync();
        return entities.Select(entity => _mapper.ToDto(entity)).ToList();
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        var entity = await _dbcontext.Reports.FirstOrDefaultAsync(e => e.Id == id);

        if (entity == null)
        {
            return Guid.Empty;
        }

        _dbcontext.Reports.Remove(entity);
        await _dbcontext.SaveChangesAsync();

        return entity.Id;
    
    }

}