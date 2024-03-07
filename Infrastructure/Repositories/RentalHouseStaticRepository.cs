using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public partial class RentalHouseRepository
{
    public async Task<int> GetTotalRentalHouses(int id)
    {
        var totalRentalHouses = await _context.RentalHouses
        .Where(r => r.IdPublication == id)
        .CountAsync();

        

        return totalRentalHouses;

    }

}