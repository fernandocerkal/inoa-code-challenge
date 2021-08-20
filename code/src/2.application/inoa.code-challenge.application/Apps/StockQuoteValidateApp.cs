using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.domain.Interfaces.Apps;
using inoa.code_challenge.domain.Interfaces.Services;

namespace inoa.code_challenge.application.Apps
{
    public class StockQuoteValidateApp : IStockQuoteValidateApp
    {
        private readonly IStockQuoteValidateService _stockQuoteValidateService;
        public StockQuoteValidateApp(IStockQuoteValidateService stockQuoteValidateService)
        {
            _stockQuoteValidateService = stockQuoteValidateService;
        }

        public bool Validate(StockQuoteValidateRequest request) => _stockQuoteValidateService.Validate(request);
    }
}
