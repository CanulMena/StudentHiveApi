using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class RequestRepository
{
    private readonly StudentHiveApiDbContext _context;

    public RequestRepository(StudentHiveApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Request>> GetAllRequests()
    {
        return await _context.Requests
        .Include(r => r.IdUserNavigation)
        .Include(r => r.IdPublicationNavigation)
        // .Include(r => r.IdEventNavigation)
        .ToListAsync();
    }

    public async Task<Request> GetRequestById(int id)
    {
        var request = await _context.Requests
        .Include(r => r.IdUserNavigation)
        .Include(r => r.IdPublicationNavigation)
        .FirstOrDefaultAsync(r => r.IdRequest == id);

        return request ?? new Request();
    }

    public async Task<Request> CreateRequest(Request request)
    {
        _context.Requests.Add(request);
        await _context.SaveChangesAsync();
        return request;
    }

    public async Task UpdateRequest(Request request)
    {
        _context.Entry(request).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRequest(int id)
    {
        var request = await _context.Requests
        .Include(r => r.IdPublicationNavigation)
        .Include(r => r.IdUserNavigation)
        .FirstOrDefaultAsync(r => r.IdRequest == id);
        if(request != null)
        {
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Request>> GetRequestsByUserId(int id)
    {
        return await _context.Requests
        .Where(r => r.IdUser == id)
        .Include(r => r.IdUserNavigation)
        .Include(r => r.IdPublicationNavigation)        
        .ToListAsync();
    }

    public async Task<IEnumerable<Request>> GetRequestsByPublicationId(int id)
    {
        return await _context.Requests
        .Where(r => r.IdPublication == id)
        .Include(r => r.IdUserNavigation)
        .Include(r => r.IdPublicationNavigation)
        .ToListAsync();
    }
}