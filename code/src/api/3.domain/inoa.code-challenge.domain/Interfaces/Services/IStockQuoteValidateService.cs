using System.Threading.Tasks;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Interfaces.Services
{    
    public interface IStockQuoteValidateService
    {
        Task<StockAlertDTO> Validate(StockQuoteValidateRequest request);
    }
}