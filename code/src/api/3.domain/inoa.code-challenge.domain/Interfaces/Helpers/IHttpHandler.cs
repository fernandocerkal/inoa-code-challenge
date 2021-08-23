using System.Threading.Tasks;

namespace inoa.code_challenge.domain.Interfaces.Services
{    
    public interface IHttpHandler
    {
        Task<string> GetStringAsync(string stockName);        
    }
}