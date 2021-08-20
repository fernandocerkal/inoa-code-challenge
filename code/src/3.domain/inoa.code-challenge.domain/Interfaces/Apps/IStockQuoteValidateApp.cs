using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Interfaces.Apps
{    
    public interface IStockQuoteValidateApp
    {
        bool Validate(StockQuoteValidateRequest request);
    }
}