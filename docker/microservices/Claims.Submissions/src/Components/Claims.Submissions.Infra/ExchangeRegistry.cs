using Claims.Submissions.Domain.Events;
using NetFusion.RabbitMQ.Publisher;

namespace Claims.Submissions.Infra
{
    public class ExchangeRegistry : ExchangeRegistryBase
    {
        protected override void OnRegister()
        {
            DefineTopicExchange<OccurrenceSubmittedEvent>("OccurrenceSubmitted", "testBus");
        }
    }
}