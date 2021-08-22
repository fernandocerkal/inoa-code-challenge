using System;
using inoa.code_challenge.application.Apps;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Data.Enums;
using inoa.code_challenge.domain.Model.DTO.Message;
using NSubstitute;
using Xunit;

namespace inoa.code_challenge.applicationTest
{
    public class StockQuoteValidateAppTest
    {
        [Theory]
        [InlineData("PETR4", 22.67, 22.59, 22.69, EStockAlert.ask)]
        [InlineData("PETR4", 22.67, 22.59, 22.53, EStockAlert.bid)]
        public async void ValidateTest(string stockName, double maxPrice, double minPrice, double currentPrice, EStockAlert stockAlert)
        {            
            var service = Substitute.For<IStockQuoteValidateService>();

            var request = new StockQuoteValidateRequest()
            {
                  StockName = stockName
                , MinPrice  = minPrice
                , MaxPrice  = maxPrice                
            };

            var response = new StockAlertDTO(stockName, currentPrice, stockAlert);           

            service.Validate(request).Returns(response);

            var test = new StockQuoteValidateApp(service);

            var validateResponse = await test.Validate(request);

            Assert.Equal(validateResponse.Data.Price     , response.Price);
            Assert.Equal(validateResponse.Data.StockName , response.StockName);
            Assert.Equal(validateResponse.Data.StockAlert, response.StockAlert);            

            service.Received(1).Validate(request);
            
        }
    }
}
