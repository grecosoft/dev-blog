using NetFusion.Settings;

[ConfigurationSection("microservice:settings")]
public class MicroserviceSettings : IAppSettings
{
    public string Name { get; set; }
    public string Author { get; set;}
    public string Language { get; set;}
}