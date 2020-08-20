using NetFusion.Bootstrap.Plugins;

namespace Claims.Submissions.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "7ab118ce-9620-48f3-96c9-2a9db96f63e8";
        public override PluginTypes PluginType => PluginTypes.ApplicationPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}