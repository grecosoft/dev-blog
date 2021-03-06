using NetFusion.Bootstrap.Plugins;

namespace RefMicroServ.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "311e9b88-d10a-436a-9540-579fb260b8b7";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}