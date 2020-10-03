using NetFusion.Bootstrap.Plugins;

namespace Kube.Service.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "3b89758b-9fb1-4e1b-b01e-4d7a650a07c1";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}