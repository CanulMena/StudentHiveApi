using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public partial class RentalHouseRepository
{
    private readonly StudentHiveApiDbContext _context;

    public RentalHouseRepository(StudentHiveApiDbContext context)
    {
        this._context = context;
    }

    //Vista previa de publicaciones

public async Task<IEnumerable<RentalHouse>> GetAllFilter(QueryRentalHouse queryRentalHouse)
{
    var query = _context.RentalHouses
    .Include(r => r.IdHouseServiceNavigation)
    .Include(r => r.IdLocationNavigation)
    .Include(r => r.Images)
    .Include(r => r.IdLocationNavigation)
    .Include(r => r.IdRentalHouseDetailNavigation)
    .AsQueryable()
    .ApplyFilter(queryRentalHouse);

    var rentalHouse = await query.ToListAsync();
    return rentalHouse;
}
public async Task<(List<RentalHouse> Items, int TotalCount, int TotalPages)> GetAll(int pageNumber = 1, int pageSize = 10)
{
    var totalCount = await _context.RentalHouses.CountAsync();
    var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    var items = await _context.RentalHouses
        .Include(r => r.IdHouseServiceNavigation)
        .Include(r => r.Images)
        .Include(r => r.IdLocationNavigation)
        .Include(r => r.IdUserNavigation)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return (items, totalCount, totalPages);
}

    //aqui se va a ver todo lo que contiene rentalHouse
    public async Task<RentalHouse> GetById(int id)
    {
        var rentalHouse = await _context.RentalHouses
        .Include(r => r.IdHouseServiceNavigation)
        .Include(r => r.Images)
        // .Include(r => r.Requests)
        .Include(r => r.IdLocationNavigation)
        .Include(r => r.IdRentalHouseDetailNavigation)
        // .Include(r => r.IdTypeReportNavigation)
        .Include(r => r.IdUserNavigation)
        
        .FirstOrDefaultAsync(rentalHouse => rentalHouse.IdPublication == id);
        return rentalHouse ?? new RentalHouse();
    }

    public async Task<RentalHouse> GetByUserId(int id)
    {
        var rentalHouse = await _context.RentalHouses
        .Include(r => r.IdHouseServiceNavigation)
        .Include(r => r.Images)
        .Include(r => r.Requests)
        .Include(r => r.IdLocationNavigation)
        .Include(r => r.IdRentalHouseDetailNavigation)
        .Include(r => r.IdUserNavigation)

        .FirstOrDefaultAsync(rentalHouse => rentalHouse.IdUser == id);
        return rentalHouse ?? new RentalHouse();
    }

    public async Task Add(RentalHouse rentalHouse)
    {
        await _context.AddAsync(rentalHouse);
        await _context.SaveChangesAsync();
    }

  public async Task Update(RentalHouse rentalHouse)
    {
        _context.RentalHouses.Update(rentalHouse);
        await _context.SaveChangesAsync();
    }

public async Task Delete(int id)
{
    var rentalHouse = await _context.RentalHouses
    .Include(r => r.Images)
    .Include(r => r.IdLocationNavigation)
    .Include(r => r.IdRentalHouseDetailNavigation)
    .FirstOrDefaultAsync(r => r.IdPublication == id);
    if (rentalHouse != null)
    {
        _context.Images.RemoveRange(rentalHouse.Images);
        _context.RentalHouses.Remove(rentalHouse);
        await _context.SaveChangesAsync();
    }
}
}