using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Reports;

public class ReportService
{
    private readonly ReportRepository _reportRepository;

    public ReportService(ReportRepository reportRepository)
    {
        this._reportRepository = reportRepository;
    }

    public async Task<IEnumerable<Report>> GetAll()
    {
        return await _reportRepository.GetAll();
    }

    public async Task<Report> GetById(int reportId)
    {
        return await _reportRepository.GetById(reportId);
    }

public async Task<List<Report>> GetReportByPublicationId(int publicationId)
{
    return await _reportRepository.GetByPublicationId(publicationId);
}

    public async Task<List<Report>> GetReportByUserId(int userId)
    {
        return await _reportRepository.GetByUserId(userId);
    }

    public async Task<List<Report>> GetReportByReportTypeId(int reportTypeId)
    {
        return await _reportRepository.GeybyReportTypeId(reportTypeId);
    }

    public async Task<Report> CreateReport(Report report)
    {
        return await _reportRepository.Add(report);
    }



    public async Task UpdateReport(Report report)
    {
         await _reportRepository.Update(report);
    }

    public async Task DeleteReport(int reportId)
    {
        await _reportRepository.Delete(reportId);
    }  
}