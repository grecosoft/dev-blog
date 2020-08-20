using NetFusion.Bootstrap.Plugins;
using Claims.Alerts.Infra.Plugin.Modules;

namespace Claims.Alerts.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "ecc77fac-787b-4335-917e-882aa0c9d973";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
