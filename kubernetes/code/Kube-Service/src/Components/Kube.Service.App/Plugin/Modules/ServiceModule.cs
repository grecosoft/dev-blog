using Kube.Service.Domain;
using Microsoft.Extensions.DependencyInjection;
using NetFusion.Bootstrap.Catalog;
using NetFusion.Bootstrap.Plugins;

namespace Kube.Service.App.Plugin.Modules
{
    public class ServiceModule : PluginModule
    {
        public override void ScanPlugins(ITypeCatalog catalog)
        {
            catalog.AsImplementedInterface("Service", ServiceLifetime.Scoped);
        }

        public override void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ILivenessProbe, LivenessProbe>();
        }
    }
}
