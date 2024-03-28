using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Dtos.QueryFilters;
using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Reports;

namespace StudentHive.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;
    private readonly IMapper _mapper;

    public ReportController(ReportService reportService, IMapper mapper)
    {
        this._reportService = reportService;
        this._mapper = mapper;
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetAllFilter([FromQuery] QueryReport queryReport)
    {
        var reports = await _reportService.GetAllFilter(queryReport);
        var reportDtos = _mapper.Map<IEnumerable<ReportDto>>(reports);
        return Ok(reportDtos);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var reports = await _reportService.GetAll();
       var reportDtos = _mapper.Map<IEnumerable<ReportDto>>(reports);
        return Ok(reportDtos);
    }

    [HttpGet("{reportId}")]
    public async Task<IActionResult> GetById(int reportId)
    {
        var report = await _reportService.GetById(reportId);
        if (report.IdReport <= 0)
        {
            return NotFound();
        }
        var reportDto = _mapper.Map<ReportDto>(report);
        return Ok(reportDto);
    }

    [HttpGet("publication/{publicationId}")]
    public async Task<IActionResult> GetReportByPublicationId(int publicationId)
    {
        var reports = await _reportService.GetReportByPublicationId(publicationId);
        if (reports.IdPublication <= 0)
        {
            return NotFound();
        }
        var reportDtos = _mapper.Map<PublicationWithReportsDto>(reports);
        return Ok(reportDtos);
    }

    // [HttpGet("user/{userId}")]
    // public async Task<IActionResult> GetReportByUserId(int userId)
    // {
    //     var reports = await _reportService.GetReportByUserId(userId);
    //     if (!reports.Any())
    //     {
    //         return NotFound();
    //     }
    //     var reportDtos = _mapper.Map<List<ReportDto>>(reports);
    //     return Ok(reportDtos);
    // }
    
    // [HttpGet("reportType/{reportTypeId}")]
    // public async Task<IActionResult> GetReportByReportTypeId(int reportTypeId)
    // {
    //     var reports = await _reportService.GetReportByReportTypeId(reportTypeId);
    //     if (!reports.Any())
    //     {
    //         return NotFound();
    //     }
    //     var reportDtos = _mapper.Map<List<ReportDto>>(reports);
    //     return Ok(reportDtos);
    // }

    // [HttpPost]
    // public async Task<IActionResult> CreateReport([FromQuery]CreateReportDTO createReportDTO)
    // {
    //     var Entity = _mapper.Map<Report>(createReportDTO);
    //     await _reportService.CreateReport(Entity);

    //     var reportDto = _mapper.Map<ReportDto>(Entity);

    //     return CreatedAtAction(nameof(GetById), new { reportId = reportDto.IdReport }, reportDto);
    // }

    // [HttpPut]
    // public async Task<IActionResult> UpdateReport([FromBody] UpdateReportDTO reportDto)
    // {
    //     var report = _mapper.Map<Report>(reportDto);
    //     await _reportService.UpdateReport(report);
    //     return Ok();
    // }

    [HttpDelete("{reportId}")]
    public async Task<IActionResult> DeleteReport(int reportId)
    {
        await _reportService.DeleteReport(reportId);
        return Ok();
    }
}