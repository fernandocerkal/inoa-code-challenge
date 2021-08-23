using System;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace inoa.code_challenge.infra
{
    public class SendMailHelper : ISendMailHelper
    {     
        private readonly SmtpConfiguration _configuration;        
        public SendMailHelper(SmtpConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(string message)
        {            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.EmailHandler.From));
            email.To.Add(MailboxAddress.Parse(_configuration.EmailHandler.To));
            email.Subject = _configuration.EmailHandler.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };

            var passArray = Convert.FromBase64String(_configuration.SmtpServerPassword);
            string password = System.Text.ASCIIEncoding.ASCII.GetString(passArray);         
            
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.SmtpServerHost, _configuration.SmtpServerPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.SmtpServerLogin, password);
            smtp.Send(email);
            smtp.Disconnect(true);
            return true;           
        }
    }
}