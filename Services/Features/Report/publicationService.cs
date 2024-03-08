using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Reports;

public class PublicationService
{
    private readonly PublicationReportRepository _reportRepository;

    public PublicationService(PublicationReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<(List<RentalHouse> Items, int TotalCount, int TotalPages)> GetAprove(int pageNumber = 1, int pageSize = 10)
    {
        return await _reportRepository.GetAllAprove(pageNumber, pageSize);
    }

    public async Task<(List<RentalHouse> Items, int TotalCount, int TotalPages)> GetReported(int pageNumber = 1, int pageSize = 10)
    {
        return await _reportRepository.GetAllReport(pageNumber, pageSize);
    }
}