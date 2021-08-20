namespace inoa.code_challenge.domain.Model.DTO.Message
{
    public class StockQuoteValidateRequest
    {
        public string StockName { get; set; }          
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}