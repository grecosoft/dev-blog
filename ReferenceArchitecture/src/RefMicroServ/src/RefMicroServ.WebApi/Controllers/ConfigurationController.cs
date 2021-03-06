using Microsoft.AspNetCore.Mvc;
using RefMicroServ.App;

namespace RefMicroServ.WebApi.Controllers
{
    [ApiController, Route("api/configs")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ConnectionSettings _connections;
        private readonly ProcessingSettings _processing;
        
        public ConfigurationController(
            ConnectionSettings connections,
            ProcessingSettings processing)
        {
            _connections = connections;
            _processing = processing;
        }


        [HttpGet("connections")]
        public ConnectionSettings GetConnections() => _connections;


        [HttpGet("processing")]
        public ProcessingSettings GetProcessing() => _processing;
    }
}