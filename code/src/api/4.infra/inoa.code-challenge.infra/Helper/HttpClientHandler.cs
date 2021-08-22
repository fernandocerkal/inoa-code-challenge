using System;
using System.Net.Http;
using System.Threading.Tasks;
using inoa.code_challenge.domain.Interfaces.Services;

namespace inoa.code_challenge.infra
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly HttpClient _client;
        
        public HttpClientHandler(HttpClient client)
        {
            _client = client;
        }

        //public Uri BaseAddress { get; set; }

        public async Task<string> GetStringAsync(string stockName)
        {
            return await _client.GetStringAsync(string.Concat(_client.BaseAddress.AbsoluteUri, stockName));
        }
    }
}