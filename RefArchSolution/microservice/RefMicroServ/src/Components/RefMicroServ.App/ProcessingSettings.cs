using System.Collections.Generic;
using NetFusion.Settings;

namespace RefMicroServ.App
{
    [ConfigurationSection("configs:processing")]
    public class ProcessingSettings : IAppSettings
    {
        public string AccessKey { get; set; }
        public ICollection<Handler> PreHandlers { get; set; } = new List<Handler>();
        public ICollection<Handler> PostHandlers { get; set; } = new List<Handler>();
    }
}