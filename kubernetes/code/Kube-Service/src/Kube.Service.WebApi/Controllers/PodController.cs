using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;

[ApiController, Route("api/pod")]
public class PodController : ControllerBase
{
    private readonly MicroserviceSettings _settings;

    public PodController(MicroserviceSettings settings)
    {
        _settings = settings;
    }

    [HttpGet("host-name")]
    public IActionResult GetHostName() => Ok(Environment.GetEnvironmentVariable("HOSTNAME"));
    

    [HttpGet("environment-variables")]
    public IActionResult GetMachineName() => Ok(Environment.GetEnvironmentVariables());
    

    [HttpGet("app-settings")]
    public IActionResult GetAppSettings() => Ok(_settings);

}