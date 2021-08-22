using System;
using System.Net;
using System.Net.Mail;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.Configuration;

namespace inoa.code_challenge.infra
{
    public class SendMailHelper : ISendMailHelper
    {     
        private readonly SmtpConfiguration _configuration;        
        public SendMailHelper(SmtpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(MailMessage message)
        {            
            using (var client = new SmtpClient(_configuration.SmtpServerHost, _configuration.SmtpServerPort))
            {
                client.UseDefaultCredentials = false;
                var passArray = Convert.FromBase64String(_configuration.SmtpServerPassword);
                string password = System.Text.ASCIIEncoding.ASCII.GetString(passArray);     
                //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             
                client.Credentials = new NetworkCredential(_configuration.SmtpServerLogin, password);
                client.EnableSsl = _configuration.SmtpServerEnableSSL;

                client.Send(message);
                return true;                
            }
        }
    }
}