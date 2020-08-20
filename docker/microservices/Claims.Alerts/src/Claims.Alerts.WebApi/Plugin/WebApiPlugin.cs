using NetFusion.Bootstrap.Plugins;

namespace Claims.Alerts.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public override string PluginId => "fddc50e7-737b-48a9-8798-3f356e6b645b";
        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string Name => "WebApi REST Host";

        public WebApiPlugin()
        {
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}