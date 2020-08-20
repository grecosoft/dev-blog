using NetFusion.Bootstrap.Plugins;
using Claims.Submissions.App.Plugin.Modules;

namespace Claims.Submissions.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "10a64d0e-2345-4402-853d-5a50aceeb99b";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}