using Newtonsoft.Json;

namespace inoa.code_challenge.infra.Model.Adapters.AlphaVantage
{
    public class StockQuoteResponse 
    {
        [JsonProperty("Global Quote")]
        public StockQuoteDataResponse Data { get; set; }        
    }

    public class StockQuoteDataResponse 
    {
        [JsonProperty("01. symbol")]
        public string Symbol { get; set; }
        [JsonProperty("05. price")]
        public string Price { get; set; }
    }

    
}