using System;
using System.IO;
using System.Threading.Tasks;
using inoa.code_challenge.console.Manager;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace inoa.code_challenge.console
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            var endpoint = new Uri(configuration["Api:Endpoint"]);

            await new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddLogging();                
                services.AddHostedService<TimedHostedService>((h) => new TimedHostedService(h.GetService<ILogger<TimedHostedService>>()));
            })            
            .RunConsoleAsync();	
        }
    }
}
