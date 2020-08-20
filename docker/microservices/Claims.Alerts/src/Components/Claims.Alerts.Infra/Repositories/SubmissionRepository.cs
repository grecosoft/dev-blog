using System.Threading.Tasks;
using Claims.Alerts.App.Repositories;
using Claims.Alerts.Domain.Entities;
using MongoDB.Driver;
using NetFusion.MongoDB;

namespace Claims.Alerts.Infra.Repositories
{
    public class SubmissionRepository: ISubmissionRepository
    {
        private readonly IMongoCollection<OccurrenceAlert> _occurrences;
        
        public SubmissionRepository(IMongoDbClient<AlertsDb> alertsDb)
        {
            _occurrences = alertsDb.GetCollection<OccurrenceAlert>();
        }

        public Task AddOccurrenceAlert(OccurrenceAlert alert)
        {
            return _occurrences.InsertOneAsync(alert);
        }
    }
}