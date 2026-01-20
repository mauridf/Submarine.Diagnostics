using Microsoft.AspNetCore.Mvc;
using Submarine.Diagnostics.Application.UseCases;
using Submarine.Diagnostics.Domain;

namespace Submarine.Diagnostics.Api.Controllers;

[ApiController]
[Route("api/diagnostics")]
public class DiagnosticsController : ControllerBase
{
    private readonly ICalculatePowerConsumptionUseCase _useCase;

    public DiagnosticsController(
        ICalculatePowerConsumptionUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost("power-consumption")]
    public ActionResult<PowerConsumptionResult> Calculate(
        [FromBody] IEnumerable<string> report)
    {
        var result = _useCase.Execute(report);
        return Ok(result);
    }
}
