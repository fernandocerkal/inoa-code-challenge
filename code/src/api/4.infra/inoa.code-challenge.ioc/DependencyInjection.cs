using System;
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
        public static void Configure(IServiceCollection services
                                   , SmtpConfiguration smtpConfiguration
                                   , StockQuoteAPIConfiguration stockQuoteAPIConfiguration)
        {   
            services.AddScoped<ISendMailHelper>(m => new SendMailHelper(smtpConfiguration));            
            services.AddScoped<IMailAdapter>(x => new MailAdapter(x.GetService<ISendMailHelper>(), smtpConfiguration));            
            
            services.AddHttpClient<IHttpHandler, HttpClientHandler>(h => h.BaseAddress = new Uri(stockQuoteAPIConfiguration.BaseURI));  

            services.AddScoped<IStockQuoteAdapter>(x => new StockQuoteAdapter(x.GetService<IHttpHandler>()));

            services.AddScoped<IStockQuoteValidateApp>(x=> new StockQuoteValidateApp(x.GetService<IStockQuoteValidateService>()));
            services.AddScoped<IStockQuoteValidateService>(x=> new StockQuoteValidateService(x.GetService<IMailAdapter>(),x.GetService<IStockQuoteAdapter>()));
            
        }
    }
}
