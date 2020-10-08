using System;
using Microsoft.AspNetCore.Mvc;

namespace Kube.Service.WebApi
{
    [ApiController, Route("api/config")]
    public class ConfigController : ControllerBase
    {
        [HttpGet("command-args")]
        public IActionResult GetEnvVars() => Ok(Environment.GetCommandLineArgs());

    }
}