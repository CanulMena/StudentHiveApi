using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.CoudinaryRentalHouses;
using StudentHive.Services.Features.RentalHouses;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class RentalHouseController : ControllerBase
{
    private readonly RentalHouseService _rentalHouseService;
    private readonly IMapper _mapper;
    private readonly CloudinaryRentalHouse _coudinaryRentalHouse;

    public RentalHouseController(RentalHouseService rentalHouseService, IMapper mapper,CloudinaryRentalHouse coudinaryRentalHouse)
    {
        this._rentalHouseService = rentalHouseService;
        this._coudinaryRentalHouse = coudinaryRentalHouse;
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

        var rentalHouseToRentalHouseDto = _mapper.Map<RentalHouseDto>(rentalHouse);

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

        var rentalHouseToRentalHouseDto = _mapper.Map<RentalHouseDto>(rentalHouse);

        return Ok(rentalHouseToRentalHouseDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add( RentalHouseCreateDto rentalHouseCreateDto)
    {   
        var entity = _mapper.Map<RentalHouse>(rentalHouseCreateDto);
        //Subir todas las imagenes
        for (int i = 0; i < rentalHouseCreateDto.ImagesFiles.Count; i++)
        {
        var image = rentalHouseCreateDto.ImagesFiles[i];
            Console.WriteLine(image);
        if (image?.Length > 0)
        {
            var imageUrl = await _coudinaryRentalHouse.UploadImageAsync(image);
            entity.Images.Add(new Image { UrlImageHouse = imageUrl });
        }
}

        await _rentalHouseService.Add(entity);

        var rentalHouseDto = _mapper.Map<RentalHouseDto>(entity);

        return CreatedAtAction(nameof(GetById), new { id = entity.IdPublication }, rentalHouseDto);
    }


[HttpPut]
public async Task<IActionResult> Update(int id, RentalHouseUpdateDto rentalHouseUpdateDTO)
{
    var entity = await _rentalHouseService.GetById(id);
    if (entity == null)
    {
        return NotFound();
    }

    _mapper.Map(rentalHouseUpdateDTO, entity);

    // Delete existing images
    if (rentalHouseUpdateDTO.ImagesFiles != null)
    {
        foreach (var image in entity.Images)
        {
            await _coudinaryRentalHouse.DeleteImageAsync(image.UrlImageHouse);
        }
        entity.Images.Clear();

        // Upload new images
        for (int i = 0; i < rentalHouseUpdateDTO.ImagesFiles.Count; i++)
        {
            var image = rentalHouseUpdateDTO.ImagesFiles[i];
            if (image?.Length > 0)
            {
                var imageUrl = await _coudinaryRentalHouse.UploadImageAsync(image);
                entity.Images.Add(new Image { UrlImageHouse = imageUrl });
            }
        }
    }

    await _rentalHouseService.Update(entity);

    return NoContent();
}

[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var entity = await _rentalHouseService.GetById(id);
    if (entity == null)
    {
        return NotFound();
    }

    // Delete images
    foreach (var image in entity.Images)
    {
        await _coudinaryRentalHouse.DeleteImageAsync(image.UrlImageHouse);
    }

    await _rentalHouseService.Delete(id);

    return NoContent();
}

}