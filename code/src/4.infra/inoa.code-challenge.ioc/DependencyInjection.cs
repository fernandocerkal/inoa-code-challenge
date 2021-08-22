using inoa.code_challenge.application.Apps;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Interfaces.Apps;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.Configuration;
using inoa.code_challenge.domain.Services;
using inoa.code_challenge.infra;
using Microsoft.Extensions.DependencyInjection;

namespace inoa.code_challenge.ioc
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services, SmtpConfiguration smtpConfiguration, StockQuoteAPIConfiguration stockQuoteAPIConfiguration)
        {            
            services.AddScoped<IMailAdapter>(m => new MailAdapter(smtpConfiguration));
            services.AddScoped<IStockQuoteAdapter>(x => new StockQuoteAdapter(stockQuoteAPIConfiguration));
            services.AddScoped<IStockQuoteValidateApp>(x=> new StockQuoteValidateApp(x.GetService<IStockQuoteValidateService>()));
            services.AddScoped<IStockQuoteValidateService>(x=> new StockQuoteValidateService(x.GetService<IMailAdapter>(),x.GetService<IStockQuoteAdapter>()));
            
        }
    }
}
