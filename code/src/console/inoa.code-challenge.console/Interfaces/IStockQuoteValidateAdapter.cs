using System.Threading.Tasks;
using inoa.code_challenge.console.Model.DTO;
using inoa.code_challenge.console.Model.DTO.Message;

namespace inoa.code_challenge.console.Interfaces
{
    public interface IStockQuoteValidateAdapter
    {
        Task<BaseResponse<StockAlertDTO>> Validate(StockQuoteValidateRequest request);
    }
}