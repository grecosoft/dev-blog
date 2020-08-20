using System;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Bootstrap.Container;
using NetFusion.Messaging;

namespace Claims.Submissions.WebApi.Controllers
{
    /// <summary>
    /// Example controller returning the a detailed log describing
    /// the plugins from which the application was composed.
    /// </summary>
    [ApiController, Route("api/composite")]
    public class CompositeController : ControllerBase
    {
        private readonly ICompositeApp _compositeApp;
        private readonly IMessagingService _messaging;
        
        public CompositeController(ICompositeApp compositeApp, IMessagingService messaging)
        {
            _compositeApp = compositeApp ?? throw new ArgumentNullException(nameof(compositeApp));
            _messaging = messaging;
        }

        [HttpGet("log")]
        public IActionResult GetLog()
        {
            return Ok(_compositeApp.Log);
        }
    }
}