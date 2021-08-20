using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Interfaces.Adapters
{    
    public interface IStockQuoteAdapter
    {
        StockQuoteDTO GetStockQuote(StockQuoteValidateRequest request);
    }
}