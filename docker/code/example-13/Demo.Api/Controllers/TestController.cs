using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController, Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet("data")]
        public IActionResult GetData() => Ok(new [] { 100, 200, 300 });
    }
}