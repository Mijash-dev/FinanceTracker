using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.controllers;

[ApiController]
[Route("Health-controller")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthly"
        });
    }
}