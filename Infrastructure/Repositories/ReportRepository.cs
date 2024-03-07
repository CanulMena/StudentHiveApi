using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class ReportRepository
{
    private readonly StudentHiveDbContext _context;

    public ReportRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Report>> GetAll()
    {
        var reports = await _context.Reports
            .Include(r => r.IdUser)
            .Include(r => r.IdReportTypeNavigation)
            .ToListAsync();
        return reports;
    }

    public async Task<Report> GetById(int id)
    {
        var report = await _context.Reports
            .Include(r => r.IdUser)
            .Include(r => r.IdReportTypeNavigation)
            .FirstOrDefaultAsync(report => report.IdReport == id);
        return report ?? new Report();
    }

    public async Task Add(Report report)
    {
        await _context.AddAsync(report);
    }

    //! Se padra hacer un update a un reporte?
    // public async Task Update(Report report)
    // {
    //     _context.Update(report);
    // }

    public async Task Delete(int id)
    {
        var report = await GetById(id);
        _context.Reports.Remove(report);
    }
}