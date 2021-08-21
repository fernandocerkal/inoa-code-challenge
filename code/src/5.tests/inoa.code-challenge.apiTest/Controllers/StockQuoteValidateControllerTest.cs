using inoa.code_challenge.domain.Interfaces.Apps;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Data.Enums;
using inoa.code_challenge.domain.Model.DTO.Message;
using NSubstitute;
using Xunit;
using Microsoft.Extensions.Logging;
using inoa.code_challenge.api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace inoa.code_challenge.apiTest
{    
    public class StockQuoteValidateControllerTest
    {
        [Theory]
        [InlineData("PETR4", 22.67, 22.59, 22.69, EStockAlert.ask)]
        public void ValidateTest(string stockName, double maxPrice, double minPrice, double currentPrice, EStockAlert stockAlert)
        {
            var log = Substitute.For<ILogger<StockQuoteValidateController>>();
            var app = Substitute.For<IStockQuoteValidateApp>();

            var request = new StockQuoteValidateRequest()
            {
                  StockName = stockName
                , MinPrice  = minPrice
                , MaxPrice  = maxPrice                
            };

            var response = new BaseResponse<StockAlertDTO>()
            {
                Situation = true,
                Data = new StockAlertDTO(stockName, currentPrice, stockAlert)
            };

            app.Validate(request).Returns(response);

            var test = new StockQuoteValidateController(log, app);

            var validateResponse = test.Validate(request);

            Assert.True(validateResponse.Result is OkObjectResult);            

            app.Received(1).Validate(request);
            
        }

        //todo: testar exception
    }
}
