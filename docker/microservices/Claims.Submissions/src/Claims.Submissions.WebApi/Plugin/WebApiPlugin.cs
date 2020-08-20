using NetFusion.Bootstrap.Plugins;

namespace Claims.Submissions.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public override string PluginId => "27e021f4-311a-4ef7-928f-52e905226132";
        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string Name => "WebApi REST Host";

        public WebApiPlugin()
        {
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}