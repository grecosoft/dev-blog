using NetFusion.Settings;

namespace RefMicroServ.App
{
    [ConfigurationSection("configs:connections")]
    public class ConnectionSettings : IAppSettings
    {
        public string Metadata { get; set; }
        public string Templates { get; set; }
        public string Render { get; set; }
    }
}