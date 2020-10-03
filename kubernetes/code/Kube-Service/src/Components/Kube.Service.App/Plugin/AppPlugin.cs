using NetFusion.Bootstrap.Plugins;
using Kube.Service.App.Plugin.Modules;

namespace Kube.Service.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "8d97f5e6-38d5-456e-b1a6-16e88169bb6a";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}