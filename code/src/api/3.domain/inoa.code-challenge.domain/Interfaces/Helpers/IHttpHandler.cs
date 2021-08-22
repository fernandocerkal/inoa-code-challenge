using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace inoa.code_challenge.domain.Interfaces.Services
{    
    public interface IHttpHandler
    {
        HttpResponseMessage Get(string url);
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
        Task<string> GetStringAsync(string requestUri);
        Uri BaseAddress { get; set; }
    }
}