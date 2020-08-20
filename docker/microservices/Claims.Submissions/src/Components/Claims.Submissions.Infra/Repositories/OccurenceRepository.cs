using System.Threading.Tasks;
using Claims.Submissions.App.Repositories;
using Claims.Submissions.Domain.Entities;
using MongoDB.Driver;
using NetFusion.MongoDB;

namespace Claims.Submissions.Infra.Repositories
{
    public class OccurenceRepository: IOccurenceRepository
    {
        private readonly IMongoCollection<Occurrence> _occurrences;
        
        public OccurenceRepository(IMongoDbClient<ClaimsDb> alertsDb)
        {
            _occurrences = alertsDb.GetCollection<Occurrence>();
        }

        public Task AddOccurrenceAsync(Occurrence occurrence)
        {
            return _occurrences.InsertOneAsync(occurrence);
        }

        public Task<Occurrence> ReadOccurrenceAsync(string id)
        {
            return _occurrences.Find(e => e.OccurrenceId == id).FirstOrDefaultAsync();
        }

        public Task UpdateOccurrenceAsync(Occurrence occurrence)
        {
            return _occurrences.ReplaceOneAsync(e => e.OccurrenceId == occurrence.OccurrenceId, occurrence);
        }
    }
}