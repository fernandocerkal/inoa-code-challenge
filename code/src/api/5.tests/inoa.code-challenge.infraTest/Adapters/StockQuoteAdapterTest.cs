using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.infra;
using inoa.code_challenge.infra.Model.Adapters.AlphaVantage;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;

namespace inoa.code_challenge.infraTest.Adapters
{
    public class StockQuoteAdapterTest
    {
        [Theory]
        [InlineData("PETR4", "22.45")]
        public async void GetStockQuoteTest(string stockName, string price)
        {
            var request = new StockQuoteValidateRequest() { StockName = stockName };
            var response = new StockQuoteResponse()
            {
                Data = new StockQuoteDataResponse() {
                    Price = price,
                    Symbol = stockName
                }
            };

            var httpClient  = Substitute.For<IHttpHandler>();           

            httpClient.GetStringAsync(Arg.Any<string>()).Returns(JsonConvert.SerializeObject(response));
                        
            var test = new StockQuoteAdapter(httpClient);

            var result = await test.GetStockQuote(request);

            Assert.Equal(result.Price, double.Parse(response.Data.Price));
            Assert.Equal(result.StockName, response.Data.Symbol);


            await httpClient.Received(1).GetStringAsync(Arg.Any<string>());
        }
    }
}
