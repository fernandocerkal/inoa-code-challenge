using inoa.code_challenge.domain.Interfaces.Adapters;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Mail;
using inoa.code_challenge.domain.Model.DTO.Mail.Enums;
using inoa.code_challenge.domain.Model.DTO.Message;

namespace inoa.code_challenge.domain.Services
{
    public class StockQuoteValidate : IStockQuoteValidateService
    {
        private readonly IMailAdapter _mailAdapter;
        private readonly IStockQuoteAdapter _stockQuoteAdapter;
        public StockQuoteValidate(IMailAdapter mailAdapter,
                                  IStockQuoteAdapter stockQuoteAdapter/*,
                                  InoaCodeChallengeConfiguration configuration*/)
        {
            _mailAdapter = mailAdapter;
            _stockQuoteAdapter = stockQuoteAdapter;
        }

        public bool Validate(StockQuoteValidateRequest request)
        {
            var stockQuote = _stockQuoteAdapter.GetStockQuote(request);

            if (stockQuote.Price > request.MaxPrice)            
                return SendMail(request, stockQuote, EIndicate.ask);
            else 
            if (stockQuote.Price < request.MinPrice)
                return SendMail(request, stockQuote, EIndicate.bid);

            return false;
        }

        private bool SendMail(StockQuoteValidateRequest request, StockQuoteDTO stockQuote, EIndicate indicateAction)
        {
            var mailData = new MailDataDTO()
            {
                  StockName      = request.StockName
                , Price          = stockQuote.Price
                , IndicateAction = indicateAction
            };

            return _mailAdapter.SendMail(mailData);
        }
    }
}