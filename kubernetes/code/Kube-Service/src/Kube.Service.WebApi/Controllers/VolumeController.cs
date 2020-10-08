using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kube.Service.WebApi 
{
    [ApiController, Route("api/volume")]
    public class VolumeController : ControllerBase
    {
        [HttpPost("add-file")]
        public async Task<IActionResult> AddNewFile([FromQuery]string value)
        {        
            Console.WriteLine(value);

            string tempFileName = Path.GetFileName(Path.GetTempFileName());

            await System.IO.File.WriteAllTextAsync(
                Path.Join("/data/files", tempFileName), 
                value);
            return Ok();
        }

        [HttpGet("file-data")]
        public IActionResult GetFileData()
        {
            var allFileLines = Directory.GetFiles("/data/files")
                .Select(fileName => System.IO.File.ReadAllText(fileName))
                .ToArray();

            return Ok(allFileLines);
        }

        [HttpGet("git-repo")]
        public async Task<IActionResult> ListGitRepoFiles([FromQuery]string file)
        {
            string filePath = Path.Join("/data/git/repo", file);

            if (! System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string[] content = await System.IO.File.ReadAllLinesAsync(filePath);
            return Ok(content);
        }

        [HttpGet("host-data")]
        public async Task<IActionResult> ListHostFiles([FromQuery] string file)
        {
            string filePath = Path.Join("/host/settings", file);

            if (! System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string[] content = await System.IO.File.ReadAllLinesAsync(filePath);
            return Ok(content);
        }
    }
}