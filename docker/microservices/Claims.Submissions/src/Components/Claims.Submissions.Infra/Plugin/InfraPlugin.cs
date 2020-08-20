using NetFusion.Bootstrap.Plugins;
using Claims.Submissions.Infra.Plugin.Modules;

namespace Claims.Submissions.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "84533594-87d6-40f8-b906-7517e565b388";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
