using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHiveApi.Services.Features.PswdHasher;
using StudentHive.Domain.Dtos;

namespace StudentHive.Services.Features.Reports;

public class ReportService
{
    private readonly ReportRepository _resportRepository;

    public ReportService(ReportRepository reportRepository)
    {
        _resportRepository = reportRepository;
    }

    public async Task<IEnumerable<Report>> GetAll()
    {
        var reports = await _resportRepository.GetAll();
        if (reports == null)
        {
            throw new InvalidOperationException("Reports not found.");
        }
        return reports;
    }

    public async Task<Report> GetById(int id)
    {
        var report = await _resportRepository.GetById(id);

        if (report == null)
        {
            throw new InvalidOperationException($"Report with ID {id} not found.");
        }
        return report;
    }

    public async Task<Report> GetByAdd(int id)
    {
        var report = await _resportRepository.GetById(id);

        if (report == null)
        {
            throw new InvalidOperationException($"Report with ID {id} not found.");
        }
        return report;
    }

    public async Task Add(Report report)
    {
        await _resportRepository.Add(report);
    }

    public async Task Delete(int id) 
    {
        await _resportRepository.Delete(id);
    }
}   
