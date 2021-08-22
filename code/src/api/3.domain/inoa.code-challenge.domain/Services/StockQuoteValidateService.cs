using System.Threading.Tasks;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Data.Enums;
using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Services
{
    public class StockQuoteValidateService : IStockQuoteValidateService
    {        
        private readonly IMailAdapter _mailAdapter;
        private readonly IStockQuoteAdapter _stockQuoteAdapter;
        
        public StockQuoteValidateService(IMailAdapter mailAdapter,
                                  IStockQuoteAdapter stockQuoteAdapter)
        {
            _mailAdapter = mailAdapter;
            _stockQuoteAdapter = stockQuoteAdapter;
        }

        public async Task<StockAlertDTO> Validate(StockQuoteValidateRequest request)
        {
            var stockQuote = await _stockQuoteAdapter.GetStockQuote(request);
            
            if (stockQuote.Price > request.MaxPrice)                        
                return SendMail(request, stockQuote, EStockAlert.ask);                            
            else 
                if (stockQuote.Price < request.MinPrice)            
                    return SendMail(request, stockQuote, EStockAlert.bid);                            
            
            return new StockAlertDTO(request.StockName, stockQuote.Price, EStockAlert.none);            
        }

        private StockAlertDTO SendMail(StockQuoteValidateRequest request, StockQuoteDTO stockQuote, EStockAlert stockAlert)
        {
            var stockAltertDTO = new StockAlertDTO(request.StockName, stockQuote.Price, stockAlert);

            _mailAdapter.SendMail(stockAltertDTO);

            return stockAltertDTO;
        }
    }
}