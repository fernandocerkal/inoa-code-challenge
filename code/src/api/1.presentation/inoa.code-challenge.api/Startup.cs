using inoa.code_challenge.domain.Model.Configuration;
using inoa.code_challenge.ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace inoa.code_challenge.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "inoa.code-challenge.api", Version = "v1" });
            });

            var smtpConfiguration = new SmtpConfiguration();
            new ConfigureFromConfigurationOptions<SmtpConfiguration>(Configuration.GetSection("SmtpConfiguration")).Configure(smtpConfiguration);
            
            var stockQuoteAPIConfiguration = new StockQuoteAPIConfiguration();
            new ConfigureFromConfigurationOptions<StockQuoteAPIConfiguration>(Configuration.GetSection("StockQuoteAPIConfiguration")).Configure(stockQuoteAPIConfiguration);
            
            //todo: verificar ioC de configuracoes
            DependencyInjection.Configure(services, smtpConfiguration, stockQuoteAPIConfiguration);                       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Luiz Santos Code Challenge");
            });
        }
    }
}
