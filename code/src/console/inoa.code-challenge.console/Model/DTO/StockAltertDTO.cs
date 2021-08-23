using inoa.code_challenge.console.Model.DTO.Enums;

namespace inoa.code_challenge.console.Model.DTO
{
    public class StockAlertDTO
    {
        public StockAlertDTO(string stockName, double price, EStockAlert stockAlert)
        {
            this.StockName = stockName;
            this.Price = price;
            this.StockAlert = stockAlert;
        }

        public string StockName { get; set; }     
        public double Price { get; set; }
        public EStockAlert StockAlert { get; set; }
    }
}