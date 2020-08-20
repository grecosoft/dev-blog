using Claims.Alerts.App.IntegrationEvents;
using Claims.Alerts.Domain.Entities;
using NetFusion.MongoDB;

namespace Claims.Alerts.Infra.Repositories.Mappings
{
    public class OccurrenceAlertMap : EntityClassMap<OccurrenceAlert>
    {
        public OccurrenceAlertMap()
        {
            CollectionName = "Submissions.Occurrences";
            AutoMap();

            MapStringPropertyToObjectId(c => c.OccurrenceId);
        }
    }
}