using System;
using System.Threading;
using System.Threading.Tasks;
using inoa.code_challenge.console.Interfaces;
using inoa.code_challenge.console.Model.DTO.Enums;
using inoa.code_challenge.console.Model.DTO.Message;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace inoa.code_challenge.console.Manager
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly IStockQuoteValidateAdapter _stockQuoteValidateAdapter;
        private readonly StockQuoteValidateRequest _stockQuoteValidateRequest;
        private Timer _timer;
        private const int time = 5;

        public TimedHostedService(ILogger<TimedHostedService> logger, 
                                  IStockQuoteValidateAdapter stockQuoteValidateAdapter, 
                                  StockQuoteValidateRequest stockQuoteValidateRequest)
        {
            _logger = logger;
            _stockQuoteValidateAdapter = stockQuoteValidateAdapter;
            _stockQuoteValidateRequest = stockQuoteValidateRequest;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(time));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            Console.WriteLine($"Monitorando {_stockQuoteValidateRequest} com intervalo de {time} minutos...");
            try
            {
                var response = await _stockQuoteValidateAdapter.Validate(_stockQuoteValidateRequest);
                if (response.Situation)
                {
                    switch(response.Data.StockAlert)
                    {
                        case EStockAlert.ask:
                            Console.WriteLine("Validação realizada. Enviada recomendação de venda por e-mail.");
                            break;
                        case EStockAlert.bid:
                            Console.WriteLine("Validação realizada. Enviada recomendação de compra por e-mail.");
                            break;
                        default:
                            Console.WriteLine("Validação realizada. Nenhuma recomendação foi enviada.");
                            break;
                    }                    
                }
                else                
                    Console.WriteLine("Validação não foi realizada.");                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro na integração com a API: ");
                Console.WriteLine(ex.Message);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}