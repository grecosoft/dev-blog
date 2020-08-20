using System.Threading.Tasks;
using Claims.Alerts.App.IntegrationEvents;
using Claims.Alerts.App.Repositories;
using Claims.Alerts.Domain.Entities;
using Microsoft.Extensions.Logging;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.RabbitMQ.Subscriber;

namespace Claims.Alerts.App.Handlers
{
    public class OccurrenceReportedHandler : IMessageConsumer
    {
        private readonly ILogger _logger;
        private readonly ISubmissionRepository _submissionRepo;
        
        public OccurrenceReportedHandler(
            ILogger<OccurrenceReportedHandler> logger,
            ISubmissionRepository submissionRepo)
        {
            _logger = logger;
            _submissionRepo = submissionRepo;
        }
        
        [TopicQueue("testBus", "NewEnglandStates", "OccurrenceSubmitted",
            "NY", "CT", "ME")]
        public async Task OnVehicleTotaled(OccurrenceSubmittedEvent integrationEvt)
        {
            _logger.LogDebug(integrationEvt.ToIndentedJson());

            var alert = new OccurrenceAlert
            {    
                OccurrenceId = integrationEvt.OccurrenceId,
                FirstName = integrationEvt.FirstName,
                LastName = integrationEvt.LastName,
                InsuredState = integrationEvt.InsuredState,
                PolicyNumber = integrationEvt.PolicyNumber,
                DateOfOccurrence = integrationEvt.DateOfOccurrence
            };
            
            await _submissionRepo.AddOccurrenceAlert(alert);
        }
    }
}