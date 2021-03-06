using NetFusion.Bootstrap.Plugins;
using RefMicroServ.App.Plugin.Modules;

namespace RefMicroServ.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "f6406cf8-6767-4f00-9e1d-230bd192c9dc";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}