﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetFusion.Bootstrap.Container;
using NetFusion.Builder;
using NetFusion.Common.Extensions.Collections;
using NetFusion.Serilog;
using RefMicroServ.App;
using Serilog;
using Serilog.Events;
using RefMicroServ.WebApi.Plugin;

namespace RefMicroServ.WebApi
{
    // Initializes the application's configuration and logging then delegates 
    // to the Startup class to initialize HTTP pipeline related settings.
    public class Program
    {
        // Allows changing the minimum log level of the service at runtime.
        private static readonly LogLevelControl LogLevelControl = new LogLevelControl();
        
        public static async Task Main(string[] args)
        {
            IHost webHost = BuildWebHost(args);
            
            var compositeApp = webHost.Services.GetService<ICompositeApp>();
            var lifetime = webHost.Services.GetService<IHostApplicationLifetime>();

            var c = webHost.Services.GetService<IConfiguration>();

            lifetime.ApplicationStopping.Register(() =>
            {
                compositeApp.Stop();
                Log.CloseAndFlush();
            });
                  
            await compositeApp.StartAsync();
            await webHost.RunAsync();    
        }

        private static IHost BuildWebHost(string[] args) 
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureLogging(SetupLogging)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureServices(sc =>
                    {
                        // Register Log Level Control so it can be injected into
                        // a service at runtime to change the level.
                        sc.AddLogLevelControl(LogLevelControl);
                    });
                })
                .UseSerilog()
                .Build();
        }

        private static void SetupConfiguration(HostBuilderContext context, 
            IConfigurationBuilder builder)
        {
            //builder.AddAppSettings(context.HostingEnvironment);
            
            AddJsonFiles(builder, "/etc/ref-arch-srv/configs");
            AddJsonFiles(builder, "/etc/ref-arch-srv/secrets");
        }

        private static void AddJsonFiles(IConfigurationBuilder builder, string directory)
        {
            Directory.GetFiles(directory, "*.json")
                .ForEach(f => builder.AddJsonFile(f, false, true));
        }

        private static void SetupLogging(HostBuilderContext context, 
            ILoggingBuilder builder)
        {
            var seqUrl = context.Configuration.GetValue("logging:seqUrl", string.Empty);
            if (string.IsNullOrEmpty(seqUrl))
            {
                Debug.WriteLine("URL for SEQ not configured.");
            }

            // Send any Serilog configuration issue logs to console.
            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
            Serilog.Debugging.SelfLog.Enable(Console.Error);

            var logConfig = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)

                .Enrich.FromLogContext()
                .Enrich.WithCorrelationId()
                .Enrich.WithHostIdentity(WebApiPlugin.HostId, WebApiPlugin.HostName)

                .WriteTo.ColoredConsole();

            if (! string.IsNullOrEmpty(seqUrl))
            {
                logConfig.WriteTo.Seq(seqUrl);
            }

            Log.Logger = logConfig.CreateLogger();
        }
    }
}
