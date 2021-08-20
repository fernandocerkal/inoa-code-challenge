using inoa.code_challenge.domain.Model.DTO.Mail.Enums;

namespace inoa.code_challenge.domain.Model.DTO.Mail
{
    public class MailDataDTO
    {
        public string StockName { get; set; }     
        public double Price { get; set; }
        public EIndicate IndicateAction { get; set; }
    }
}