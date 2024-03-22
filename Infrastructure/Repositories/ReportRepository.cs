using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class ReportRepository
{
    private readonly StudentHiveApiDbContext _context;

    public ReportRepository(StudentHiveApiDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Report>> GetAll()
    {
        return await _context.Reports
            .Include(r => r.IdTypeReportNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.IdPublicationNavigation)
            .ToListAsync();
    }

    public async Task<Report> GetById(int id)
    {
        var report = await _context.Reports
            .Include(r => r.IdTypeReportNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.IdPublicationNavigation)
            .FirstOrDefaultAsync(r => r.IdReport == id);
        return report ?? new Report();
    }
    
    public async Task<List<Report>> GetByPublicationId(int id)
    {
        var reports = await _context.Reports
            .Include(r => r.IdTypeReportNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.IdPublicationNavigation)
            .Where(r => r.IdPublication == id)
            .ToListAsync();
        return reports;
    }

    public async Task<List<Report>> GetByUserId(int id)
    {
        var report = await _context.Reports
            .Include(r => r.IdTypeReportNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.IdPublicationNavigation)
            .Where(r => r.IdUser == id)
            .ToListAsync();
        return report;
    }

    public async Task<List<Report>> GeybyReportTypeId(int id)
    {
        var report = await _context.Reports
            .Include(r => r.IdTypeReportNavigation)
            .Include(r => r.IdUserNavigation)
            .Include(r => r.IdPublicationNavigation)
            .Where(r => r.IdTypeReport == id)
            .ToListAsync();
        return report;
    }

    public async Task<Report> Add(Report report)
    {
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
        return report;
    }

    public async Task Update(Report report)
    {
        _context.Reports.Update(report);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var report = await _context.Reports
            .FirstOrDefaultAsync(r => r.IdReport == id);
        if (report != null)
        {
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
        }
    }
}