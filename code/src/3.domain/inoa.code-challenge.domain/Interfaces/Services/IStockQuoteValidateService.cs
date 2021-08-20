using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Interfaces.Services
{    
    public interface IStockQuoteValidateService
    {
        bool Validate(StockQuoteValidateRequest request);
    }
}