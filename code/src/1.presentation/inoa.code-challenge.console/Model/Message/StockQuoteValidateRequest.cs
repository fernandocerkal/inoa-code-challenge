using System.Text;

namespace inoa.code_challenge.console.Model.DTO.Message
{
    public class StockQuoteValidateRequest
    {        
        public string StockName { get; set; }                  
        public double MinPrice { get; set; }        
        public double MaxPrice { get; set; }

        public static bool TryParse(string[] args, out StockQuoteValidateRequest request)
        {
            request = null;
            double minPrice, maxPrice;

            if (string.IsNullOrEmpty(args[0]))           
                return false;
                
            if (double.TryParse(args[1], out maxPrice) &&
                double.TryParse(args[2], out minPrice)) 
            {

                request = new StockQuoteValidateRequest()
                {
                    StockName = args[0]
                    , MaxPrice = maxPrice
                    , MinPrice = minPrice
                };

                return true;
            }
            return false;
        }

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