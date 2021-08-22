using System.Globalization;

namespace inoa.code_challenge.domain.Model.DTO.Data
{
    public class StockAltertMailData
    {
        public string StockName { get; set; }     
        public string Price { get; set; }

        public static StockAltertMailData FromStockAlert(StockAlertDTO stockAlert)
        {
            return new StockAltertMailData()
            {
                  StockName = stockAlert.StockName
                , Price = stockAlert.Price.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))
            };            
        }
    }
}