using NetFusion.Settings;

namespace Kube.Service.App
{

    [ConfigurationSection("microservice:settings")]
    public class MicroserviceSettings : IAppSettings
    {
        public string Name { get; set; }
        public string Author { get; set;}
        public string Language { get; set;}
    }
}