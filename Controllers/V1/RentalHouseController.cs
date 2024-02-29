using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.RentalHouses;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class RentalHouseController : ControllerBase
{
    private readonly RentalHouseService _rentalHouseService;
    private readonly IMapper _mapper;

    public RentalHouseController(RentalHouseService rentalHouseService, IMapper mapper)
    {
        this._rentalHouseService = rentalHouseService;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var publications = await _rentalHouseService.GetAll();
        var publicationDtos = _mapper.Map<IEnumerable<PublicationDtos>>(publications);
        return Ok(publicationDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {       //entity RentalHouse
        var rentalHouse = await _rentalHouseService.GetById(id);
        if (rentalHouse.IdPublication <= 0)
        {
            return NotFound();
        }

        var rentalHouseToRentalHouseDto = _mapper.Map<RentalHouseDTO>(rentalHouse);

        return Ok(rentalHouseToRentalHouseDto);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var rentalHouse = await _rentalHouseService.GetByUserId(id);
        if (rentalHouse.IdPublication <= 0)
        {
            return NotFound();
        }

        var rentalHouseToRentalHouseDto = _mapper.Map<RentalHouseDTO>(rentalHouse);

        return Ok(rentalHouseToRentalHouseDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(RentalHouseCreateDTO rentalHouseCreateDto)
    {
        var entity = _mapper.Map<RentalHouse>(rentalHouseCreateDto);

        await _rentalHouseService.Add(entity);

        var rentalHouseDto = _mapper.Map<RentalHouseDTO>(entity);

        return CreatedAtAction(nameof(GetById), new { id = entity.IdPublication }, rentalHouseDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, RentalHouseCreateDTO rentalHouseCreateDto)
    {
        var entity = _mapper.Map<RentalHouse>(rentalHouseCreateDto);
        entity.IdPublication = id;

        await _rentalHouseService.Update(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _rentalHouseService.Delete(id);

        return NoContent();
    }

}