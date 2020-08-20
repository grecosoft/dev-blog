using System.Threading.Tasks;
using Claims.Submissions.Domain.Entities;

namespace Claims.Submissions.App.Repositories
{
    public interface IOccurenceRepository
    {
        Task AddOccurrenceAsync(Occurrence occurrence);
        Task<Occurrence> ReadOccurrenceAsync(string id);
        Task UpdateOccurrenceAsync(Occurrence occurrence);
    }
}