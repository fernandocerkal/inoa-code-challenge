using System;
using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.domain.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using inoa.code_challenge.domain.Model.DTO.Data;
using System.Threading.Tasks;

namespace inoa.code_challenge.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class StockQuoteValidateController : ControllerBase
    {
        private readonly ILogger<StockQuoteValidateController> _logger;
        private readonly IStockQuoteValidateApp _stockQuoteValidateApp;

        public StockQuoteValidateController(ILogger<StockQuoteValidateController> logger, 
                                            IStockQuoteValidateApp stockQuoteValidateApp)
        {
            _logger = logger;
            _stockQuoteValidateApp = stockQuoteValidateApp;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<StockAlertDTO>>> Validate(StockQuoteValidateRequest request)
        {
            var requestId = Guid.NewGuid();
            try
            {                   
                _logger.LogInformation($"RX:{requestId}:StockQuoteValidateController.Validate");

                if (ModelState.IsValid)
                {                       
                    var response = await _stockQuoteValidateApp.Validate(request);                    
                    return Ok(response);
                }
                else
                {
                    _logger.LogInformation($"TX:{requestId}:StockQuoteValidateController.Validate Error. Model is invalid!");
                    return BadRequest(new BaseResponse<StockAlertDTO>()
                    {
                        Situation = false,
                        Message = "Invalid Model"
                    });
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation($"TX:{requestId}:StockQuoteValidateController.Validate Exception. Model is invalid!");
                _logger.LogError($"TX:{requestId}:StockQuoteValidateController.Validate Exception", ex);

                return BadRequest(new BaseResponse<StockAlertDTO>()
                {
                    Situation = false,
                    Message = ex.Message
                });
            }
        }
    }
}