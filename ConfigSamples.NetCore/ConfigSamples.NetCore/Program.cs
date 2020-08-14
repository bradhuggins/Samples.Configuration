using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConfigSamples.NetCore
{
    public class Program
    {
        public static readonly Dictionary<string, string> _dict =
           new Dictionary<string, string>
           {
                    {"MemoryCollectionKey1", "value1"},
                    {"MemoryCollectionKey2", "value2"},
                    {"samplekeymemory", "hello world from Memory!" }
           };

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration 
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());

                    config.AddIniFile("custom_config.ini", optional: true, reloadOnChange: true);

                    config.AddXmlFile("custom_config.xml", optional: true, reloadOnChange: true);

                    config.AddJsonFile("custom_config.json", optional: false, reloadOnChange: false);

                    config.AddInMemoryCollection(_dict);

                    // Call AddEnvironmentVariables last if you need to allow environment
                    // variables to override values from other providers.
                    config.AddEnvironmentVariables(prefix: "CONFIG_");

                    //// Call AddCommandLine last to allow arguments to override other configuration.
                    //config.AddCommandLine(args);
                })


                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
