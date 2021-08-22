using System;
using System.IO;
using System.Threading.Tasks;
using inoa.code_challenge.console.Adapter;
using inoa.code_challenge.console.Interfaces;
using inoa.code_challenge.console.Manager;
using inoa.code_challenge.console.Model.DTO.Message;
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
            StockQuoteValidateRequest stockQuoteValidateRequest = null; 
            
            if (StockQuoteValidateRequest.TryParse(args, out stockQuoteValidateRequest))
            {
                await Starting(stockQuoteValidateRequest);
                await new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();
                    services.AddHttpClient<IStockQuoteValidateAdapter, StockQuoteValidateAdapter>(h => h.BaseAddress = endpoint);
                    services.AddHostedService<TimedHostedService>((h) => new TimedHostedService(h.GetService<ILogger<TimedHostedService>>(),
                                                                                                h.GetService<IStockQuoteValidateAdapter>(),
                                                                                                stockQuoteValidateRequest));
                })
                .RunConsoleAsync();
                Console.WriteLine($"Monitoramento iniciado!");
            }
            else
            {
                Console.WriteLine("O programa foi finalizado pois os parâmetros informados são inválidos.");
                Console.WriteLine("Veja o exemplo: ");
                Console.WriteLine("DLL -> dotnet run inoa.code-challenge.console.dll PETR4 22.23 22.10");
                Console.WriteLine("EXE -> inoa.code-challenge.console.exe PETR4 22.23 22.10");
            }
        }

        private static async Task Starting(StockQuoteValidateRequest stockQuoteValidateRequest)
        {
            Console.WriteLine($"Iniciando o monitoramento de {stockQuoteValidateRequest}");
            await Task.Delay(5000);
        }
    }
}
