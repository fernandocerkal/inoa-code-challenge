using System;
using System.Net.Mail;
using inoa.code_challenge.domain.Interfaces.Services;
using inoa.code_challenge.domain.Model.Configuration;
using inoa.code_challenge.domain.Model.DTO.Data;
using inoa.code_challenge.domain.Model.DTO.Data.Enums;
using inoa.code_challenge.infra;
using NSubstitute;
using Xunit;

namespace inoa.code_challenge.infraTest.Adapters
{
    public class MailAdapterTest
    {
        [Theory]
        [InlineData("PETR4", 22.67, EStockAlert.bid)]
        public void SendMail(string stockName, double price, EStockAlert stockAlert)
        {
            var data = new StockAlertDTO(stockName, price, stockAlert);            
            var sendMail  = Substitute.For<ISendMailHelper>();
            var smtpConfig = Substitute.For<SmtpConfiguration>();

            var mailMessage = new MailMessage();
            
            sendMail.Send(mailMessage).Returns(true);            
                        
            var test = Substitute.For<MailAdapter>(sendMail, smtpConfig);

            test.GetMailMessage(data).Returns(mailMessage);            

            var result = test.SendMail(data);

            Assert.True(result);            

            sendMail.Received(1).Send(mailMessage);       
        }
    }
}
