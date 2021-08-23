using System.Threading.Tasks;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.infra.Model.Adapters.AlphaVantage;
using Newtonsoft.Json;

namespace inoa.code_challenge.infra
{
    public class StockQuoteAdapter : IStockQuoteAdapter
    {           
        private readonly IHttpHandler _client;   
        public StockQuoteAdapter(IHttpHandler client)
        {            
            _client = client;
        }
        
        public async Task<StockQuoteDTO> GetStockQuote(StockQuoteValidateRequest request)
        {            
            var json     = await _client.GetStringAsync($"{request.StockName}.sao");                
            var jsonData = JsonConvert.DeserializeObject<StockQuoteResponse>(json);

            return new StockQuoteDTO()
            {
                Price = double.Parse(jsonData.Data.Price),
                StockName = request.StockName
            };
        }
    }
}
