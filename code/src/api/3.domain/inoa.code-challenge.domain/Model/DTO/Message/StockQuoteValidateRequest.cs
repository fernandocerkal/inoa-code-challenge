using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("StockQuoteValidateRequest;")
                .Append($"{StockName};")
                .Append($"{MaxPrice};")
                .Append($"{MinPrice}");
                
                return sb.ToString();            
            }
            finally
            {
                sb.Clear();
                sb = null;
            }
        }
    }
}