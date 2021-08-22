using System.Net.Http;
using System.Threading.Tasks;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Model.Configuration;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.infra.Model.Adapters.AlphaVantage;
using Newtonsoft.Json;

namespace inoa.code_challenge.infra
{
    public class StockQuoteAdapter : IStockQuoteAdapter
    {   
        private readonly StockQuoteAPIConfiguration _configuration;        
        public StockQuoteAdapter(StockQuoteAPIConfiguration configuration)
        {
            _configuration = configuration;            
        }
        
        public async Task<StockQuoteDTO> GetStockQuote(StockQuoteValidateRequest request)
        {
            //todo: inject            
            var uri = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={request.StockName}.sao&apikey={_configuration.ApiKey}";
            using (var http = new HttpClient())
            {
                var json     = await http.GetStringAsync(uri);                
                var jsonData = JsonConvert.DeserializeObject<StockQuoteResponse>(json);

                return new StockQuoteDTO()
                {
                    Price = double.Parse(jsonData.Data.Price),
                    StockName = request.StockName
                };
            }
        }
    }
}
