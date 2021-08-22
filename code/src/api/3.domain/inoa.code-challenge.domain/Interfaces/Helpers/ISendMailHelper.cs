using System.Net.Mail;

namespace inoa.code_challenge.domain.Interfaces.Services
{    
    public interface ISendMailHelper
    {
        bool Send(MailMessage message);
    }
}