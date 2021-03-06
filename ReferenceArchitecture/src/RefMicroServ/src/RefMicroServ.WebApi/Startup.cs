using System;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetFusion.Builder;
using NetFusion.Messaging.Logging;
using NetFusion.Messaging.Plugin;
using NetFusion.Rest.Server.Plugin;
using NetFusion.Serilog;
using NetFusion.Settings.Plugin;
using NetFusion.Web.Mvc.Plugin;
using RefMicroServ.App;
using Serilog;
using RefMicroServ.App.Plugin;
using RefMicroServ.Domain.Plugin;
using RefMicroServ.Infra.Plugin;
using RefMicroServ.WebApi.Hubs;
using RefMicroServ.WebApi.Plugin;

namespace RefMicroServ.WebApi
{
    // Configures the HTTP request pipeline and bootstraps the NetFusion application container.
    public class Startup
    {
        // Microsoft Abstractions:
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnv;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnv)
        {
            _configuration = configuration;
            _hostingEnv = hostingEnv;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.CompositeContainer(_configuration, new SerilogExtendedLogger())
                .AddSettings()
                .AddMessaging()
                .AddWebMvc()
                .AddRest()
 
                .AddPlugin<InfraPlugin>()
                .AddPlugin<AppPlugin>()
                .AddPlugin<DomainPlugin>()
                .AddPlugin<WebApiPlugin>()
                .Compose();

            services.AddCors();
            services.AddHttpContextAccessor();
            services.AddControllers();

            // Adds SignalR and a message log sink that delegates
            // all received messages to a SignalR Hub.
            if (_hostingEnv.IsDevelopment())
            {
                services.AddSignalR();
                services.AddMessageLogSink<HubMessageLogSink>();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string viewerUrl = _configuration.GetValue<string>("Netfusion:ViewerUrl");
            if (! string.IsNullOrWhiteSpace(viewerUrl))
            {
                app.UseCors(builder => builder.WithOrigins(viewerUrl)
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithExposedHeaders("WWW-Authenticate","resource-404")
                    .AllowAnyHeader());
            }
            
            app.UseSerilogRequestLogging();
            
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Register the SignalR Hub that a development tool can connect
                // for receiving logs of published and received messages.
                if (env.IsDevelopment())
                {
                    endpoints.MapHub<MessageLogHub>("/api/message/log");
                }
            });
        }
    }
}


// "connections": {
//     "metadata": "http://RefArch/Processing/Metadata",
//     "templates": "http://RefArch/Processing/Templates",
//     "render": "http://RefArch/Processing/render"
// },