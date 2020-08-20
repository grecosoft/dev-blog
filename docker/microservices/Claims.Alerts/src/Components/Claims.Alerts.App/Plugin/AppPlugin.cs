using NetFusion.Bootstrap.Plugins;
using Claims.Alerts.App.Plugin.Modules;

namespace Claims.Alerts.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "41d5b4d4-4510-4deb-8dfa-05ecfc4e8849";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}