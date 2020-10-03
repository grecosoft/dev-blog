using NetFusion.Bootstrap.Plugins;

namespace Kube.Service.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public override string PluginId => "0ec0e7bd-ea08-4952-bf15-20ce694da89b";
        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string Name => "WebApi REST Host";

        public WebApiPlugin()
        {
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}