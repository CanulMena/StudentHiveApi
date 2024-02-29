using AutoMapper;
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

    public async Task<IEnumerable<RentalHouse>> GetAll()
    {
        var rentalHouses = await _rentalHouseRepository.GetAll();
        return rentalHouses;
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