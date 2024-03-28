namespace Infrastructure.Repositories;

using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;

public static class QueryExtensions
{
    public static IQueryable<RentalHouse> ApplyFilter(this IQueryable<RentalHouse> query, QueryRentalHouse filter)
    {
        if (!string.IsNullOrWhiteSpace(filter.WhoElse))
        {
            query = query.Where(r => r.WhoElse.Contains(filter.WhoElse));
        }

        if (filter.BelowDatePublication > DateTime.UnixEpoch)
        {
            query = query.Where(r => r.PublicationDate <= filter.BelowDatePublication);
        }

        if (filter.OverDatePublication > DateTime.UnixEpoch)
        {
            query = query.Where(r => r.PublicationDate >= filter.OverDatePublication);
        }

        if (filter.BelowPrice.HasValue)
        {
            query = query.Where(r => r.RentPrice <= filter.BelowPrice);
        }

        if (filter.OverPrice.HasValue)
        {
            query = query.Where(r => r.RentPrice >= filter.OverPrice);
        }

        if (!string.IsNullOrWhiteSpace(filter.TypeHouse))
        {
            query = query.Where(r => r.TypeHouse.Contains(filter.TypeHouse));
        }

        if (!string.IsNullOrWhiteSpace(filter.Address))
        {
            query = query.Where(r => r.IdLocationNavigation!.Address.Contains(filter.Address));
        }

        if (!string.IsNullOrWhiteSpace(filter.City))
        {
            query = query.Where(r => r.IdLocationNavigation!.City.Contains(filter.City));
        }

        if (!string.IsNullOrWhiteSpace(filter.Country))
        {
            query = query.Where(r => r.IdLocationNavigation!.Country.Contains(filter.Country));
        }

        if(filter.PostalCode > 0)
        {
            query = query.Where(r => r.IdLocationNavigation!.PostalCode == filter.PostalCode);
        }

        if(filter.Wifi)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.Wifi == filter.Wifi);
        }

        if(filter.Kitchen)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.Kitchen == filter.Kitchen);
        }

        if(filter.Washer)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.Washer == filter.Washer);
        }

        if(filter.AirConditioning)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.AirConditioning == filter.AirConditioning);
        }

        if(filter.Water)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.Water == filter.Water);
        }

        if(filter.Gas)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.Gas == filter.Gas);
        }

        if(filter.Gas)
        {
            query = query.Where(r => r.IdHouseServiceNavigation!.Gas == filter.Gas);
        }

        if(filter.NumberOfGuests.HasValue)
        {
            query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfGuests == filter.NumberOfGuests);
        }

        if(filter.NumberOfBathrooms.HasValue)
        {
            query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfBathrooms == filter.NumberOfBathrooms);
        }

        if(filter.NumberOfRooms.HasValue)
        {
            query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfRooms == filter.NumberOfRooms);
        }

        if(filter.NumbersOfBed.HasValue)
        {
            query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumbersOfBed == filter.NumbersOfBed);
        }

        if(filter.NumberOfHammocks.HasValue)
        {
            query = query.Where(r => r.IdRentalHouseDetailNavigation!.NumberOfHammocks == filter.NumberOfHammocks);
        }
        
        return query;
    }

    public static IQueryable<Report> ApplyFilter(this IQueryable<Report> query, QueryReport filter)
    {

        if (filter.BelowDatePublication > DateTime.UnixEpoch)
        {
            query = query.Where(r => r.CreatedAt <= filter.BelowDatePublication);
        }

        if (filter.OverDatePublication > DateTime.UnixEpoch)
        {
            query = query.Where(r => r.CreatedAt >= filter.OverDatePublication);
        }

        if (filter.IdPublication > 0)
        {
            query = query.Where(r => r.IdPublication == filter.IdPublication);
        }

        if (filter.IdTypeReport > 0)
        {
            query = query.Where(r => r.IdTypeReport == filter.IdTypeReport);
        }

        if (filter.IdUser > 0)
        {
            query = query.Where(r => r.IdUser == filter.IdUser);
        }

        if(!string.IsNullOrWhiteSpace(filter.TypeReportName))
        {
            query = query.Where(r => r.IdTypeReportNavigation!.TypeReportName!.Contains(filter.TypeReportName));
        }

        return query;
    }
}