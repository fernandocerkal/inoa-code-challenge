using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Interfaces.Apps
{    
    public interface IStockQuoteValidateApp
    {
        BaseResponse<StockAlertDTO> Validate(StockQuoteValidateRequest request);
    }
}