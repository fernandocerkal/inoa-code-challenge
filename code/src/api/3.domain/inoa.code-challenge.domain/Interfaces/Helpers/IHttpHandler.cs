using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace inoa.code_challenge.domain.Interfaces.Services
{    
    public interface IHttpHandler
    {
        Task<string> GetStringAsync(string stockName);
        //Uri BaseAddress { get; set; }
    }
}