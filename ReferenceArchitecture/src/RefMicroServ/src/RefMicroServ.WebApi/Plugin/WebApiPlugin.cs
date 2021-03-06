using NetFusion.Bootstrap.Plugins;

namespace RefMicroServ.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public const string HostId = "77da8bf4-cf44-4bce-9c5a-c8c7a401154b";
        public const string HostName = "";

        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string PluginId => HostId;
        public override string Name => HostName;
        
        public WebApiPlugin()
        {
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}