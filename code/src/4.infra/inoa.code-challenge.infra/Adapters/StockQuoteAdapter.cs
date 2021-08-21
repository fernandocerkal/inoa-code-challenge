using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.infra
{
    public class StockQuoteAdapter : IStockQuoteAdapter
    {      
        public StockQuoteDTO GetStockQuote(StockQuoteValidateRequest request)
        {
            //todo: remover mock
            return new StockQuoteDTO()
            {
                Price = 22,
                StockName = "PETR3"                
            };
        }
    }
}
