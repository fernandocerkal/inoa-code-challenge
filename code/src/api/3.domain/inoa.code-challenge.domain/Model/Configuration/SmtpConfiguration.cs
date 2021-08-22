namespace inoa.code_challenge.domain.Model.Configuration
{
    public class SmtpConfiguration
    {
       public string SmtpServerHost { get; set; }             
       public int SmtpServerPort { get; set; } = 465;
       public string SmtpServerLogin { get; set; }    
       public string SmtpServerPassword { get; set; }    
       public bool SmtpServerEnableSSL { get; set; } = true;
       public MailHandler EmailHandler { get; set; }        
    }
}