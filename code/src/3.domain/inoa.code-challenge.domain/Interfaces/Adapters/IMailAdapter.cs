using inoa.code_challenge.domain.Model.DTO.Data;

namespace inoa.code_challenge.domain.Interfaces.Adapters
{    
    public interface IMailAdapter
    {
        bool SendMail(StockAlertDTO stockAltert);
    }
}