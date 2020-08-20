using NetFusion.MongoDB.Settings;
using NetFusion.Settings;

namespace Claims.Submissions.Infra.Repositories
{
    [ConfigurationSection("databases:claims")]
    public class ClaimsDb : MongoSettings
    {
        
    }
}