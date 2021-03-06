using NetFusion.Bootstrap.Plugins;
using RefMicroServ.Infra.Plugin.Modules;

namespace RefMicroServ.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "9998e47d-247f-432e-9250-e957bc6f561b";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
