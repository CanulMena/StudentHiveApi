using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Services.Features.CoudinaryRentalHouses;
using StudentHive.Services.Features.RentalHouses;
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var reports = await _reportService.GetAll();
        var reportDtos = _mapper.Map<IEnumerable<ReportDTO>>(reports);
        if (reportDtos == null)
        {
            return NotFound();

        }
        return Ok(reportDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var report = await _reportService.GetById(id);
        if (report.IdReport <=  0)
        {
            return NotFound();
        }

        var reportToReportDto = _mapper.Map<ReportDTO>(report);
        return  Ok(reportToReportDto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateReportDTO createRreportDTO) 
    {
        var entity = _mapper.Map<Report>(createRreportDTO);

        await _reportService.Add(entity);

        return CreatedAtAction(nameof(GetById), new { id = entity.IdReport }, entity);
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(int id)
    {
        await _reportService.Delete(id);
        return NoContent();
    }
}