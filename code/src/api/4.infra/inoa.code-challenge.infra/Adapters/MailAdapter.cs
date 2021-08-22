using System.Net.Mail;
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

        public virtual MailMessage GetMailMessage(StockAlertDTO stockAltert)
        {
            using (var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_configuration.EmailHandler.From, _configuration.EmailHandler.FromName);
                mailMessage.Body = _configuration.EmailHandler.RenderMailBody(stockAltert);
                mailMessage.Subject = _configuration.EmailHandler.Subject;
                mailMessage.IsBodyHtml = true;

                mailMessage.To.Add(_configuration.EmailHandler.To);
                mailMessage.ReplyToList.Add(_configuration.EmailHandler.ReplyTo);
                
                return mailMessage;
            }
        }
    }
}