using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RefMicroServ.App;
using RefMicroServ.App.Configs;

namespace RefMicroServ.WebApi.Controllers
{
    [ApiController, Route("api/configs")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly RepositorySettings _repositories;
        private readonly ProcessingSettings _processors;
        
        public ConfigurationController(
            IConfiguration configuration,
            ILogger<ConfigurationController> logger,
            RepositorySettings repositories,
            ProcessingSettings processors)
        {
            _configuration = configuration;
            _logger = logger;
            _repositories = repositories;
            _processors = processors;
        }

        [HttpGet("log/url")]
        public IActionResult GetSeqLogUrl()
        {
            _logger.LogError("Test Error Log Message");
            return Ok(_configuration.GetValue<string>("logging:seqUrl"));
        }

        [HttpGet("repositories")]
        public IActionResult GetRepositories() => Ok(_repositories);


        [HttpGet("processors")]
        public IActionResult GetProcessing() => Ok(_processors);
    }
}