using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Requests;
using StudentHive.Services.Features.Users;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class RequestController : ControllerBase
{
    private readonly RequestService _requestService;
    private readonly UsersService _userService;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public RequestController(RequestService requestService, IMapper mapper, INotificationService notificationService, UsersService userService)
    {
        this._requestService = requestService;
        this._mapper = mapper;
        this._notificationService = notificationService;
        this._userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _requestService.GetAll();
        var response = new
        {
            results = _mapper.Map<IEnumerable<RequestDto>>(result)
        };
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var request = await _requestService.GetById(id);
        if (request.IdRequest <= 0)
        {
            return NotFound();
        }

        var requestToRequestDto = _mapper.Map<RequestDto>(request);

        return Ok(requestToRequestDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateRequestDto requestCreateDto)
    {
        var request = _mapper.Map<Request>(requestCreateDto);
        await _requestService.Add(request);
        return Ok();
    }

    // [HttpPut]
    // public async Task<IActionResult> Update(RequestDto requestDto)
    // {
    //     var request = _mapper.Map<Request>(requestDto);
    //     await _requestService.Update(request);
    //     return Ok();
    // }

[HttpPatch]
public async Task<IActionResult> Status(int id, StatusRequestDto statusRequestDto)
{
    var request = await _requestService.GetById(id);
    if (request.IdRequest <= 0)
    {
        return NotFound();
    }

    request.Status = statusRequestDto.Status;
    await _requestService.Update(request);

    // Si el estado es "Aceptada", enviar una notificación al usuario que hizo la solicitud
    if (statusRequestDto.Status == "Aceptada")
{
    if (request.IdUser.HasValue)
    {
        await _notificationService.SendNotification(request.IdUser.Value, "Tu solicitud ha sido aceptada.");
    }
    else
    {
        // Manejar el caso en que request.IdUser es null
    }
}

    // Si el estado es "Aceptada", enviar una notificación de "Rechazada" a los usuarios en espera
    if (statusRequestDto.Status == "Aceptada")
    {
        var waitingUsers = await _userService.GetUsersInWaitList(request.IdRequest);
        foreach (var user in waitingUsers)
        {
            await _notificationService.SendNotification(user.IdUser, "Lo sentimos, por el momento el espacio ya ha sido ocupado.");
        }
    }

    return Ok();
}
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _requestService.Delete(id);
        return Ok();
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUserId(int id)
    {
        var request = await _requestService.GetByUserId(id);
        if (request.Count() == 0)
        {
            return NotFound();
        }

        var requestToRequestDto = _mapper.Map<IEnumerable<RequestDto>>(request);

        return Ok(requestToRequestDto);
    }

    [HttpGet("publication/{id}")]
    public async Task<IActionResult> GetByPublicationId(int id)
    {
        var request = await _requestService.GetByPublicationId(id);
        if (request.Count() == 0)
        {
            return NotFound();
        }

        var requestToRequestDto = _mapper.Map<IEnumerable<RequestDto>>(request);

        return Ok(requestToRequestDto);
    }
}