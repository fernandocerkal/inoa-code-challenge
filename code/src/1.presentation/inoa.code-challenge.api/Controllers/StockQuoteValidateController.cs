using System;
using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.domain.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace inoa.code_challenge.api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class StockQuoteValidateController : ControllerBase
    {
        private readonly ILogger<StockQuoteValidateController> _logger;
        private readonly IStockQuoteValidateApp _stockQuoteValidateApp;

        public StockQuoteValidateController(ILogger<StockQuoteValidateController> logger, IStockQuoteValidateApp stockQuoteValidateApp)
        {
            _logger = logger;
            _stockQuoteValidateApp = stockQuoteValidateApp;
        }

        [HttpPost]
        public IActionResult Validate(StockQuoteValidateRequest request)
        {
            try
            {
                return Ok(true);
            }
            catch(Exception ex)
            {
                _logger.LogError("Validade", ex);
                return BadRequest(ex);
            }
        }
    }
}