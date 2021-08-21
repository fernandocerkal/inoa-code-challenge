﻿using inoa.code_challenge.domain.Model.DTO.Message;
using inoa.code_challenge.domain.Interfaces.Apps;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.DTO.Data;
using System;

namespace inoa.code_challenge.application.Apps
{
    public class StockQuoteValidateApp : IStockQuoteValidateApp
    {
        private readonly IStockQuoteValidateService _stockQuoteValidateService;
        public StockQuoteValidateApp(IStockQuoteValidateService stockQuoteValidateService)
        {
            _stockQuoteValidateService = stockQuoteValidateService;
        }

        public BaseResponse<StockAlertDTO> Validate(StockQuoteValidateRequest request) 
        {            
            var stockAlert = _stockQuoteValidateService.Validate(request);
            return new BaseResponse<StockAlertDTO>()
            {
                Data        = stockAlert,
                Situation   = true
            };            
        } 
    }
}
