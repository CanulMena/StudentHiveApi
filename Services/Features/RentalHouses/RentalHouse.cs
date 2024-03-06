using AutoMapper;
using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.RentalHouses;

public class RentalHouseService 
{
    private readonly RentalHouseRepository _rentalHouseRepository;

    public RentalHouseService(RentalHouseRepository rentalHouseRepository)
    {
        this._rentalHouseRepository = rentalHouseRepository;
    }

    public async Task<(List<RentalHouse> Items, int TotalCount, int TotalPages)> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        return await _rentalHouseRepository.GetAll(pageNumber, pageSize);
    }

    public async Task<IEnumerable<RentalHouse>> GetAllFilter(QueryRentalHouse queryRentalHouse)
    {
        return await _rentalHouseRepository.GetAllFilter(queryRentalHouse);
    }

    public async Task<int> GetTotalRentalHouses(int id)
    {
        return await _rentalHouseRepository.GetTotalRentalHouses(id);
    }

    public async Task<RentalHouse> GetById(int id)
    {   // validation entity RentalHouse
        var rentalHouse = await _rentalHouseRepository.GetById(id);

        if (rentalHouse == null)
        {
            throw new InvalidOperationException($"RentalHouse with ID {id} not found.");
        }

        return rentalHouse;
    }
     public async Task<RentalHouse> GetByIdAdd(int id)
    {   // validation entity RentalHouse
        var rentalHouse = await _rentalHouseRepository.GetById(id);

        if (rentalHouse == null)
        {
            throw new InvalidOperationException($"RentalHouse with ID {id} not found.");
        }

        return rentalHouse;
    }

    public async Task<RentalHouse> GetByUserId(int id)
    {
        var rentalHouse = await _rentalHouseRepository.GetByUserId(id);

        if (rentalHouse == null)
        {
            throw new InvalidOperationException($"User with ID {id} not found.");
        }
        return rentalHouse;
    }

    public async Task Add(RentalHouse rentalHouse)
    {
        await _rentalHouseRepository.Add(rentalHouse);
    }

    public async Task Update(RentalHouse rentalHouse)
    {
        await _rentalHouseRepository.Update(rentalHouse);
    }

    public async Task Delete(int id)
    {
        await _rentalHouseRepository.Delete(id);
    }
}