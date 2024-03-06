using Microsoft.EntityFrameworkCore;

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