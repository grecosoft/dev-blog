using System.Threading.Tasks;
using Claims.Alerts.Domain.Entities;

namespace Claims.Alerts.App.Repositories
{
    public interface ISubmissionRepository
    {
        Task AddOccurrenceAlert(OccurrenceAlert alert);
    }
}