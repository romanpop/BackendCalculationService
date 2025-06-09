using Microsoft.AspNetCore.Mvc;
using BackendCalculationService.Services;
using BackendCalculationService.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BackendCalculationService.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkbookController : ControllerBase
{
    private readonly WorkbookStorageService _storageService;
    private readonly ExcelCalculationService _calcService;

    public WorkbookController(WorkbookStorageService storageService, ExcelCalculationService calcService)
    {
        _storageService = storageService;
        _calcService = calcService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var path = await _storageService.SaveAsync(file).ConfigureAwait(false);
        return Ok(new { FilePath = path });
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate([FromBody] CalculationRequest req)
    {
        var inputs = req.Inputs ?? new Dictionary<string, object>();
        var outputs = await _calcService.CalculateAsync(req.FilePath, inputs);
        return Ok(outputs);
    }
}
