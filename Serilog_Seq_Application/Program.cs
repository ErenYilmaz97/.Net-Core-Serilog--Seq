using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Serilog_Seq_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger  = new LoggerConfiguration()
                .WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day) //HER GUN ICIN YENI DOSYA OLUSTUR
                .WriteTo.Seq("http://localhost:5341/") //LOG SERVER URL -- SEQ
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Error)
                .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureLogging(config => config.ClearProviders())
                .UseSerilog();
    }
}

