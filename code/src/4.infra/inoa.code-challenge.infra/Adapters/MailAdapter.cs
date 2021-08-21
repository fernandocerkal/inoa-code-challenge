using System.Net;
using System.Net.Mail;
using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Model.Configuration;
using inoa.code_challenge.domain.Model.DTO.Data;

namespace inoa.code_challenge.infra
{
    public class MailAdapter : IMailAdapter
    {
        private readonly SmtpConfiguration _configuration;        
        public MailAdapter(SmtpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendMail(StockAlertDTO stockAltert)
        {
            //todo: melhoria, jogar em uma fila
            using (var client = new SmtpClient(_configuration.SmtpServerHost, _configuration.SmtpServerPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials           = new NetworkCredential(_configuration.SmtpServerLogin, _configuration.SmtpServerPassword);                
                client.EnableSsl             = _configuration.SmtpServerEnableSSL;
                
                using(var mailMessage = new MailMessage())
                {
                    mailMessage.From       = new MailAddress(_configuration.EmailHandler.From, "Inoa Code Challenge");                    
                    mailMessage.Body       = _configuration.EmailHandler.RenderMailBody(stockAltert);
                    mailMessage.Subject    = _configuration.EmailHandler.Subject;
                    mailMessage.IsBodyHtml = true;

                    mailMessage.To.Add(_configuration.EmailHandler.To);
                    mailMessage.ReplyToList.Add(_configuration.EmailHandler.ReplyTo);
                    
                    client.Send(mailMessage);
            
                    return true;
                }
            }            
        }
    }
}