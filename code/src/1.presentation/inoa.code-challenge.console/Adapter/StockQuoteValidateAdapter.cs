using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using inoa.code_challenge.console.Exceptions;
using inoa.code_challenge.console.Interfaces;
using inoa.code_challenge.console.Model.DTO;
using inoa.code_challenge.console.Model.DTO.Message;
using Newtonsoft.Json;

namespace inoa.code_challenge.console.Adapter
{
    public class StockQuoteValidateAdapter : IStockQuoteValidateAdapter
    {
        private readonly HttpClient _http;
        public StockQuoteValidateAdapter(HttpClient http)
        {
            _http = http;
        }

        public async Task<BaseResponse<StockAlertDTO>> Validate(StockQuoteValidateRequest request)
        {            
           var json = JsonConvert.SerializeObject(request);
           var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);


           var result = await _http.PostAsync(_http.BaseAddress.AbsoluteUri, stringContent);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseResponse<StockAlertDTO>>(response);
            }
            else
                throw new ApiRequestException($"API Request Exception. StatusCode = {result.StatusCode}.");            
        }
    }
}