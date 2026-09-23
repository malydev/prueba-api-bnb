using ApiPruebaBnb.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaBnb.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController(IDatabaseHealthService databaseHealth) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        if (await databaseHealth.IsHealthyAsync(cancellationToken))
            return Ok(new { status = "ok" });

        return StatusCode(StatusCodes.Status503ServiceUnavailable, new { status = "unhealthy" });
    }
}
