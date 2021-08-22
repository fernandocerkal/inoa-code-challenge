using System;
using System.Net.Http;
using System.Threading.Tasks;
using inoa.code_challenge.domain.Interfaces.Services;

namespace inoa.code_challenge.infra
{
    public class HttpClientHandler : IHttpHandler
    {
        private HttpClient _client = new HttpClient();

        public Uri BaseAddress { get; set; }

        public Task<string> GetStringAsync(string requestUri)
        {
            return GetStringAsync(requestUri);
        }


        public HttpResponseMessage Get(string url)
        {
            return GetAsync(url).Result;
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            return PostAsync(url, content).Result;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }
    }
}