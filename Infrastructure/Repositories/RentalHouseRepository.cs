using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public partial class RentalHouseRepository
{
    private readonly StudentHiveDbContext _context;

    public RentalHouseRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    //Vista previa de publicaciones

public async Task<IEnumerable<RentalHouse>> GetAllFilter( QueryRentalHouse queryRentalHouse)
{
    var query = _context.RentalHouses
    .Include(r => r.IdHouseServiceNavigation)
    .Include(r => r.IdLocationNavigation)
    .Include(r => r.IdRentalHouseDetailNavigation)
    .AsQueryable();

    if(!string.IsNullOrEmpty(queryRentalHouse.WhoElse) && !string.IsNullOrWhiteSpace(queryRentalHouse.WhoElse))
    {
        query = query.Where(r => r.WhoElse.Contains(queryRentalHouse.WhoElse));
    }

    if(queryRentalHouse.BelowDatePublication > DateTime.UnixEpoch)
    {
        query = query.Where(r => r.PublicationDate <= queryRentalHouse.BelowDatePublication);
    }

    if(queryRentalHouse.OverDatePublication > DateTime.UnixEpoch)
    {
        query = query.Where(r => r.PublicationDate >= queryRentalHouse.OverDatePublication);
    }

    if(queryRentalHouse.BelowPrice.HasValue)
    {
        query = query.Where(r => r.RentPrice <= queryRentalHouse.BelowPrice);
    }

    if(queryRentalHouse.OverPrice.HasValue)
    {
        query = query.Where(r => r.RentPrice >= queryRentalHouse.OverPrice);
    }

    if(!string.IsNullOrEmpty(queryRentalHouse.TypeHouse) && !string.IsNullOrWhiteSpace(queryRentalHouse.TypeHouse))
    {
        query = query.Where(r => r.TypeHouse.Contains(queryRentalHouse.TypeHouse));
    }

    if(!string.IsNullOrEmpty(queryRentalHouse.Address) && !string.IsNullOrWhiteSpace(queryRentalHouse.Address))
    {
        query = query.Where(r => r.IdLocationNavigation!.Address.Contains(queryRentalHouse.Address));
    }

    if(!string.IsNullOrEmpty(queryRentalHouse.City) && !string.IsNullOrWhiteSpace(queryRentalHouse.City))
    {
        query = query.Where(r => r.IdLocationNavigation!.City.Contains(queryRentalHouse.City));
    }

    if(!string.IsNullOrEmpty(queryRentalHouse.State) && !string.IsNullOrWhiteSpace(queryRentalHouse.State))
    {
        query = query.Where(r => r.IdLocationNavigation!.State.Contains(queryRentalHouse.State));
    }

    if(!string.IsNullOrEmpty(queryRentalHouse.Country) && !string.IsNullOrWhiteSpace(queryRentalHouse.Country))
    {
        query = query.Where(r => r.IdLocationNavigation!.Country.Contains(queryRentalHouse.Country));
    }

    if(queryRentalHouse.PostalCode > 0)
    {
        query = query.Where(r => r.IdLocationNavigation!.PostalCode == queryRentalHouse.PostalCode);
    }

    if(queryRentalHouse.Wifi)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.Wifi == queryRentalHouse.Wifi);
    }

    if(queryRentalHouse.Kitchen)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.Kitchen == queryRentalHouse.Kitchen);
    }

    if(queryRentalHouse.Washer)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.Washer == queryRentalHouse.Washer);
    }

    if(queryRentalHouse.AirConditioning)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.AirConditioning == queryRentalHouse.AirConditioning);
    }

    if(queryRentalHouse.Water)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.Water == queryRentalHouse.Water);
    }

    if(queryRentalHouse.Gas)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.Gas == queryRentalHouse.Gas);
    }

    if(queryRentalHouse.Television)
    {
        query = query.Where(r => r.IdHouseServiceNavigation!.Television == queryRentalHouse.Television);
    }

    if(queryRentalHouse.NumberOfGuests.HasValue)
    {
        query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfGuests == queryRentalHouse.NumberOfGuests);
    }

    if(queryRentalHouse.NumberOfBathrooms.HasValue)
    {
        query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfBathrooms == queryRentalHouse.NumberOfBathrooms);
    }

    if(queryRentalHouse.NumberOfRooms.HasValue)
    {
        query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfRooms == queryRentalHouse.NumberOfRooms);
    }

    if(queryRentalHouse.NumbersOfBed.HasValue)
    {
        query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumbersOfBed == queryRentalHouse.NumbersOfBed);
    }

    if(queryRentalHouse.NumberOfHammocks.HasValue)
    {
        query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfHammocks == queryRentalHouse.NumberOfHammocks);
    }

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
        .Include(r => r.IdTypeReportNavigation)
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
    .Include(r => r.IdTypeReportNavigation)
    .FirstOrDefaultAsync(r => r.IdPublication == id);
    if (rentalHouse != null)
    {
        _context.Images.RemoveRange(rentalHouse.Images);
        _context.RentalHouses.Remove(rentalHouse);
        await _context.SaveChangesAsync();
    }
}
}