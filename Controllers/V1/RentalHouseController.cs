using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;
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

    private readonly ILogger<RentalHouseController> _logger;

    public RentalHouseController(RentalHouseService rentalHouseService, IMapper mapper,CloudinaryRentalHouse coudinaryRentalHouse, ILogger<RentalHouseController> logger)
    {
        this._rentalHouseService = rentalHouseService;
        this._coudinaryRentalHouse = coudinaryRentalHouse;
        this._mapper = mapper;
        this._logger = logger;
    }

    [HttpGet("Publications")]
    public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _rentalHouseService.GetAll(pageNumber, pageSize);
        var response = new
        {
            page = pageNumber,
            results = _mapper.Map<IEnumerable<PublicationDtos>>(result.Items),
            total_pages = result.TotalPages,
            total_results = result.TotalCount
        };
        return Ok(response);
    }

    [HttpGet("true/Publications")]
public async Task<IActionResult> GetAllTruePublications(int pageNumber = 1, int pageSize = 10)
{
    var result = await _rentalHouseService.GetAll(pageNumber, pageSize);
    
    // Filtrar los resultados para que solo incluyan publicaciones con Status = true
    var filteredItems = result.Items.Where(item => item.Status == true);

    var response = new
    {
        page = pageNumber,
        results = _mapper.Map<IEnumerable<PublicationDtos>>(filteredItems),
        total_pages = result.TotalPages,
        total_results = result.TotalCount
    };
    return Ok(response);
}

    [HttpGet("filter")]
    public async Task<IActionResult> GetAllFilter([FromQuery] QueryRentalHouse queryRentalHouse)
    {
        var rentalHouse = await _rentalHouseService.GetAllFilter(queryRentalHouse);
        var rentalHouseToRentalHouseDto = _mapper.Map<IEnumerable<RentalHouseDto>>(rentalHouse);
        return Ok(rentalHouseToRentalHouseDto);
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


    // [HttpPut]
    // public async Task<IActionResult> Update(int id, [FromQuery] RentalHouseUpdateDto rentalHouseUpdateDTO)
    // {
    //     var entity = await _rentalHouseService.GetById(id);
    //     if (entity == null)
    //     {
    //         return NotFound();
    //     }

    //     _mapper.Map(rentalHouseUpdateDTO, entity);
        
    //     if (rentalHouseUpdateDTO.ImagesFiles != null)
        
    //     {
    //         foreach (var image in entity.Images)
    //         {
    //                 try
    // {
    //     await _coudinaryRentalHouse.DeleteImageAsync(image.UrlImageHouse);
    // }
    // catch (System.Exception ex)
    // {
    //     if (!ex.Message.Contains("not found"))
    //     {
    //         throw;
    //     }
    // }
    //         }
    //         entity.Images.Clear();

    //         // Upload new images
    //         for (int i = 0; i < rentalHouseUpdateDTO.ImagesFiles.Count; i++)
    //         {
    //             var image = rentalHouseUpdateDTO.ImagesFiles[i];
    //             if (image?.Length > 0)
    //             {
    //                 var imageUrl = await _coudinaryRentalHouse.UploadImageAsync(image);
    //                 entity.Images.Add(new Image { UrlImageHouse = imageUrl });
    //             }
    //         }
    //     }
    //     await _rentalHouseService.Update(entity);

    //     return NoContent();
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _rentalHouseService.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
    
        // Eliminar imágenes
        foreach (var image in entity.Images)
        {
            try
            {
                await _coudinaryRentalHouse.DeleteImageAsync(image.UrlImageHouse);
            }
            catch (Exception ex)
            {
                // Registrar el mensaje de error y continuar con la siguiente imagen
                _logger.LogError(ex, $"Error al eliminar la imagen con URL {image.UrlImageHouse}");
            }
        }
    
        await _rentalHouseService.Delete(id);
    
        return NoContent();
    }

    [HttpPatch("{id}/Publish")]
    public async Task<IActionResult> Publish(int id, [FromQuery]UpdateStatusRentalHouseDto updateStatusRentalHouseDto)
    {
        var entity = await _rentalHouseService.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
    
        entity.Status = updateStatusRentalHouseDto.Status;
        await _rentalHouseService.Update(entity);
    
        return NoContent();
    }
    
    }