using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
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
        this._administradorService = administradorService;
        this._mapper = mapper;
    }

    [Authorize(Policy = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var administradores = await _administradorService.GetAll();
        var administradorDtos = _mapper.Map<IEnumerable<MasterDto>>(administradores);
        return Ok(administradorDtos);
    }

    [Authorize(Policy = "Administrador")]
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var administrador = await _administradorService.GetById(id);
        if (administrador.IdAdmin <= 0)
            return NotFound();

        var administradorToMasterDto = _mapper.Map<MasterDto>(administrador);

        return Ok(administradorToMasterDto);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> AuthLogin(AuthLoginDTO authLogin)
    {   //me esta regresando la instancia del usuario que existe en la base de datos con el campo de rol
        var userToken = await _administradorService.AuthLogin(authLogin);
        //* si me regresa una sentencia user() vacia tendrá id = 0
        if (userToken == "")
            return BadRequest("Invalid email or password");
        
        return Ok(userToken);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Add(CreateAdministradorDto administradorCreateDto)
    {
        var entity = _mapper.Map<Administrador>(administradorCreateDto);
        entity.Password = _administradorService.HashPassword(entity.Password);

        await
            _administradorService.Add(entity);

        var administradorDto = _mapper.Map<MasterDto>(entity);

        return CreatedAtAction(nameof(GetById), new { id = entity.IdAdmin }, administradorDto);
    }

    // [HttpPut]
    // public async Task<IActionResult> Update(int id, CreateAdministradorDto administradorUpdateDto)
    // {
    //     try
    //     {
    //         var entity = _mapper.Map<Administrador>(administradorUpdateDto);
    //         entity.IdAdmin = id;
    //         await _administradorService.Update(entity);
    //         return NoContent();
    //     }
    //     catch (Exception e)
    //     {
    //         return NotFound(e.Message);
    //     }
    // }


    [HttpPatch("{id}/email")]
    public async Task<IActionResult> UpdateEmail(int id, string email)
    {
        var entity = await _administradorService.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        entity.Email = email;
        await _administradorService.Update(entity);
        return NoContent();
    
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _administradorService.Delete(id);
        return NoContent();
    }

}