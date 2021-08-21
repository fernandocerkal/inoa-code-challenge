using System.ComponentModel.DataAnnotations;

namespace inoa.code_challenge.domain.Model.DTO.Message
{
    public class StockQuoteValidateRequest
    {
        [Required]
        public string StockName { get; set; }          
        [Required]
        public double MinPrice { get; set; }
        [Required]
        public double MaxPrice { get; set; }
    }
}