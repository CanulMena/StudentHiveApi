using Microsoft.EntityFrameworkCore;

namespace StudentHive.Infrastructure.Repositories;

public partial class ReportRepository
{
    public async Task<int> GetTotalReports(int id)
    {
        var totalReports = await _context.Reports
        .Where(r => r.IdPublication == id)
        .CountAsync();

        return totalReports;
    }
}