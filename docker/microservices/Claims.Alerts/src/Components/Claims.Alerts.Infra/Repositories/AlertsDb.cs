using NetFusion.MongoDB.Settings;
using NetFusion.Settings;

namespace Claims.Alerts.Infra.Repositories
{
    [ConfigurationSection("databases:alerts")]
    public class AlertsDb : MongoSettings
    {
        
    }
}