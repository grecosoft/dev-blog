using NetFusion.Settings;

namespace RefMicroServ.App
{
    [ConfigurationSection("configs:connections")]
    public class ConnectionSettings : IAppSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Metadata { get; set; }
        public string Templates { get; set; }
        public string Render { get; set; }
    }
}