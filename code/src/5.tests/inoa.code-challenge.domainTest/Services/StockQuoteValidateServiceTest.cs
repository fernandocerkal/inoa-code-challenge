using System;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Data.Enums;
using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.domain.Services;
using NSubstitute;
using Xunit;

namespace inoa.code_challenge.domainTest
{
    public class StockQuoteValidateServiceTest
    {
        [Theory]
        [InlineData("PETR4", 22.67, 22.59, 22.69, EStockAlert.ask)]
        [InlineData("PETR4", 22.67, 22.59, 22.53, EStockAlert.bid)]
        public void ValidateTest(string stockName, double maxPrice, double minPrice, double currentPrice, EStockAlert stockAlert)
        {            
            var mailAdapter  = Substitute.For<IMailAdapter>();
            var quoteAdapter = Substitute.For<IStockQuoteAdapter>();            

            var request = new StockQuoteValidateRequest()
            {
                  StockName = stockName
                , MinPrice  = minPrice
                , MaxPrice  = maxPrice                
            };

            var response = new StockAlertDTO(stockName, currentPrice, stockAlert);           
            var stockQuoteDTO = new StockQuoteDTO() 
            {
                  StockName = stockName
                , Price = currentPrice
            };

            mailAdapter.SendMail(response).Returns(true);
            quoteAdapter.GetStockQuote(request).Returns(stockQuoteDTO);

            var test = new StockQuoteValidateService(mailAdapter, quoteAdapter);

            var validateResponse = test.Validate(request);

            Assert.Equal(validateResponse.Price     , response.Price);
            Assert.Equal(validateResponse.StockName , response.StockName);
            Assert.Equal(validateResponse.StockAlert, response.StockAlert);            

            mailAdapter.Received(1).SendMail(Arg.Any<StockAlertDTO>());
            quoteAdapter.Received(1).GetStockQuote(request);
            
        }
    }
}
