using System.Threading.Tasks;
using Claims.Submissions.Domain.Commands;
using Claims.Submissions.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Common.Extensions.Collections;
using NetFusion.Messaging;

namespace Claims.Submissions.WebApi.Controllers
{
    [ApiController, Route("api/claims/occurrence")]
    public class OccurrenceController : ControllerBase
    {
        private readonly IMessagingService _messaging;
        
        public OccurrenceController(
            IMessagingService messaging)
        {
            _messaging = messaging;
        }
        
        [HttpPost("report")]
        public async Task<IActionResult> Report([FromBody]OccurrenceCommand command)
        {
            Confirmation confirmation = await _messaging.SendAsync(command);
            if (confirmation.Validations.Empty())
            {
                return Ok(confirmation);
            }

            return BadRequest(confirmation);
        }

        [HttpPut("{occurrenceId}/party")]
        public async Task<IActionResult> ReportInvolvedParty(string occurrenceId, 
            [FromBody]InvolvedPartyCommand command)
        {
            command.OccurrenceId = occurrenceId;
            
            Confirmation confirmation = await _messaging.SendAsync(command);
            if (confirmation.Validations.Empty())
            {
                Ok(confirmation);
            }

            return BadRequest(confirmation);
        }
    }
}