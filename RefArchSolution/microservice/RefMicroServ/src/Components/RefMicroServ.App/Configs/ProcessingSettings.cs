using System.Collections.Generic;
using NetFusion.Settings;

namespace RefMicroServ.App.Configs
{
    [ConfigurationSection("configs:processors")]
    public class ProcessingSettings : IAppSettings
    {
        public string ErrorQueueName { get; set; }
        public string SuccessQueueName { get; set; }
        public Dictionary<string, Handler> PreHandlers { get; set; } = new();
        public Dictionary<string, Handler> PostHandlers { get; set; } = new ();
    }
}