using NetFusion.Bootstrap.Plugins;

namespace Claims.Alerts.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "499db39c-461c-4f00-83d8-7bed015a73ad";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}