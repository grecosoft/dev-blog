using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kube.Service.WebApi
{
    [ApiController, Route("api/config")]
    public class ConfigController : ControllerBase
    {
        [HttpGet("command-args")]
        public IActionResult GetCommandArgs() => Ok(Environment.GetCommandLineArgs());

        [HttpGet("volume")]
        public async Task<IActionResult> ReadVolumeConfig([FromQuery]string file) 
        {
            string filePath = Path.Join("/etc/kube-config/settings", file);

            if (! System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string content = await System.IO.File.ReadAllTextAsync(filePath);
            return Ok(content);
        }
    }
}