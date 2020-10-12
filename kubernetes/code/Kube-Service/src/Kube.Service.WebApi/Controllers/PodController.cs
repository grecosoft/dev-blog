using System;
using Kube.Service.App;
using Kube.Service.Domain;
using Microsoft.AspNetCore.Mvc;

[ApiController, Route("api/pod")]
public class PodController : ControllerBase
{
    private readonly MicroserviceSettings _settings;
    private readonly ILivenessProbe _livenessProbe;

    public PodController(
        MicroserviceSettings settings,
        ILivenessProbe livenessProbe)
    {
        _settings = settings;
        _livenessProbe = livenessProbe;
    }

    [HttpGet("host-name")]
    public IActionResult GetHostName() => Ok(Environment.GetEnvironmentVariable("HOSTNAME"));
    

    [HttpGet("environment-variables")]
    public IActionResult GetEnvVars() => Ok(Environment.GetEnvironmentVariables());
    

    [HttpGet("app-settings")]
    public IActionResult GetAppSettings() => Ok(_settings);

    [HttpGet("health-check")]
    public IActionResult GetHealthCheck()
    {
        if (_livenessProbe.IsCurrentStateHealthy())
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPost("toggle-health")]
    public IActionResult ToggleHealthStatus() 
    {
        _livenessProbe.ToggleState();
        return Ok();
    }

    [HttpGet("version")]
    public IActionResult GetVersion() => Ok("v3");
}