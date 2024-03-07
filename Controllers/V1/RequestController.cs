using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Requests;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class RequestController : ControllerBase
{
    private readonly RequestService _requestService;
    private readonly IMapper _mapper;

    public RequestController(RequestService requestService, IMapper mapper)
    {
        this._requestService = requestService;
        this._mapper = mapper;
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