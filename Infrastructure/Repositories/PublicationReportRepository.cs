using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class PublicationReportRepository
{
    private readonly StudentHiveApiDbContext _context;

    public PublicationReportRepository(StudentHiveApiDbContext context)
    {
        _context = context;
    }

public async Task<(List<RentalHouse> Items, int TotalCount, int TotalPages)> GetAllAprove(int pageNumber = 1, int pageSize = 10)
{
    var totalCount = await _context.RentalHouses.CountAsync();
    var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    var items = await _context.RentalHouses
        .Include(r => r.Image)
        .Include(r => r.IdLocationNavigation)
        .Include(r => r.IdUserNavigation)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return (items, totalCount, totalPages);
}

public async Task<(List<RentalHouse> Items, int TotalCount, int TotalPages)> GetAllReport(int pageNumber = 1, int pageSize = 10)
{
    var totalCount = await _context.RentalHouses.CountAsync();
    var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    var items = await _context.RentalHouses
        .Include(r => r.Image)
        .Include(r => r.IdLocationNavigation)
        .Include(r => r.IdReport)
        .Include(r => r.IdUserNavigation)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return (items, totalCount, totalPages);
}

}