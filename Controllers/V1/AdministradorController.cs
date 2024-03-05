using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos.AdminDtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Administradors;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class AdministradorController : ControllerBase
{
    private readonly AdministradorService _administradorService;
    private readonly IMapper _mapper;

    public AdministradorController(AdministradorService administradorService, IMapper mapper)
    {
        _administradorService = administradorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var administradores = await _administradorService.GetAll();
        var administradorDtos = _mapper.Map<IEnumerable<MasterDto>>(administradores);
        return Ok(administradorDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var administrador = await _administradorService.GetById(id);
        if (administrador.IdAdmin <= 0)
            return NotFound();

        var administradorToMasterDto = _mapper.Map<MasterDto>(administrador);

        return Ok(administradorToMasterDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateAdministradorDto administradorCreateDto)
    {
        var entity = _mapper.Map<Administrador>(administradorCreateDto);

        await
            _administradorService.Add(entity);

        var administradorDto = _mapper.Map<MasterDto>(entity);

        return CreatedAtAction(nameof(GetById), new { id = entity.IdAdmin }, administradorDto);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, CreateAdministradorDto administradorUpdateDto)
    {
        try
        {
            var entity = _mapper.Map<Administrador>(administradorUpdateDto);
            entity.IdAdmin = id;
            await _administradorService.Update(entity);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _administradorService.Delete(id);
        return NoContent();
    }

}