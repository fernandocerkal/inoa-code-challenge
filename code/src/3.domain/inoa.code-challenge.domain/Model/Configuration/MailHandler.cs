using System.IO;
using System.Text;
using inoa.code_challenge.domain.Model.DTO.Data;
using Stubble.Core.Builders;

namespace inoa.code_challenge.domain.Model.Configuration
{
    public class MailHandler
    {
       public string To { get; set; }                    
       public string From { get; set; }                  
       public string ReplyTo { get; set; }                      
       public string Subject { get; set; }    
       public string ResourcesPath { get; set; }    
       
       public string RenderMailBody(StockAlertDTO stockAlert)
       {
            var stubble = new StubbleBuilder().Build();
            string output = string.Empty;

            var templatePath = Path.Combine(ResourcesPath, string.Concat(stockAlert.StockAlert,".html"));
            
            using (StreamReader streamReader = new StreamReader(ResourcesPath, Encoding.UTF8))
            {
                output = stubble.Render(streamReader.ReadToEnd(), stockAlert);
            }
            return output;
       }       
    }
}