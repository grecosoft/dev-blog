using System.Collections.Generic;
using NetFusion.Settings;

namespace RefMicroServ.App.Configs
{
    [ConfigurationSection("configs:repositories")]
    public class RepositorySettings : IAppSettings
    {
        public int DefaultTimeoutSeconds { get; set; } = 10;
        public int DefaultNumberOfRetries { get; set; } = 2;
        public Dictionary<string, Connection> Connections { get; set; } = new();
    }
}