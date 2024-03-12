using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Services.Features.Reports;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/v1/publication")]
public class PublicationReportController : ControllerBase
{
    private readonly PublicationService _publicationService;
    private readonly IMapper _mapper;

    public PublicationReportController(PublicationService publicationService, IMapper mapper)
    {
        _publicationService = publicationService;
        _mapper = mapper;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _publicationService.GetAprove(pageNumber, pageSize);
        var response = new
        {
            page = pageNumber,
            results = _mapper.Map<IEnumerable<PublicationToBeAprovedDto>>(result.Items),
            total_pages = result.TotalPages,
            total_results = result.TotalCount
        };
        return Ok(response);
    }

    [HttpGet("reported")]
    public async Task<IActionResult> GetReported(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _publicationService.GetReported(pageNumber, pageSize);
        var response = new
        {
            page = pageNumber,
            results = _mapper.Map<IEnumerable<RepotedPublicationDtos>>(result.Items),
            total_pages = result.TotalPages,
            total_results = result.TotalCount
        };
        return Ok(response);
    }

    

}