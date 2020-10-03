using NetFusion.Bootstrap.Plugins;
using Kube.Service.Infra.Plugin.Modules;

namespace Kube.Service.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "515fdfc7-ab65-4001-8700-b9af73c44971";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
