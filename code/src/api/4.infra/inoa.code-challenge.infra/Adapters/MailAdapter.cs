using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.Configuration;
using inoa.code_challenge.domain.Model.DTO.Data;

namespace inoa.code_challenge.infra
{
    public class MailAdapter : IMailAdapter
    {
        private readonly SmtpConfiguration _configuration;        
        private readonly ISendMailHelper _sendMail;
        public MailAdapter(ISendMailHelper sendMail, SmtpConfiguration configuration)
        {
            _configuration = configuration;
            _sendMail = sendMail;
        } 

        public bool SendMail(StockAlertDTO stockAltert)
        {                        
            return  _sendMail.Send(GetMailMessage(stockAltert));
        }

        public virtual string GetMailMessage(StockAlertDTO stockAltert)
        {
            return _configuration.EmailHandler.RenderMailBody(stockAltert);         
        }
    }
}