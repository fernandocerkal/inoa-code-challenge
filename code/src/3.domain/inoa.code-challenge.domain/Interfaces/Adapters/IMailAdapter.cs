using inoa.code_challenge.domain.Model.DTO.Mail;

namespace inoa.code_challenge.domain.Interfaces.Adapters
{    
    public interface IMailAdapter
    {
        bool SendMail(MailDataDTO mailData);
    }
}