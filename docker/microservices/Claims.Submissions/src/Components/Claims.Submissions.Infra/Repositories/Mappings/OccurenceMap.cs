using Claims.Submissions.Domain.Entities;
using NetFusion.MongoDB;

namespace Claims.Submissions.Infra.Repositories.Mappings
{
    public class OccurenceMap: EntityClassMap<Occurrence>
    {
        public OccurenceMap()
        {
            CollectionName = "Submissions.Occurrence";
            AutoMap();
            
            MapField("_involvedParties").SetElementName("InvolvedParties");

            MapStringPropertyToObjectId(c => c.OccurrenceId);
        }
    }
}