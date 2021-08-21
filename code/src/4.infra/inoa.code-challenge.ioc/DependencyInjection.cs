using inoa.code_challenge.application.Apps;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Interfaces.Apps;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Services;
using inoa.code_challenge.infra;
using Microsoft.Extensions.DependencyInjection;

namespace inoa.code_challenge.ioc
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IStockQuoteValidateApp, StockQuoteValidateApp>();
            services.AddScoped<IStockQuoteValidateService, StockQuoteValidateService>();
            services.AddScoped<IStockQuoteAdapter, StockQuoteAdapter>();            
            services.AddScoped<IMailAdapter, MailAdapter>();


        }
    }
}
