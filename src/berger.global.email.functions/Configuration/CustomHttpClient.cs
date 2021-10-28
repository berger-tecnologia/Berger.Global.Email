using System.Net.Http;
using Serilog.Sinks.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace berger.global.functions.Configuration
{
    public class CustomHttpClient : IHttpClient
    {
        #region Properties
        private readonly HttpClient _client;
        #endregion

        #region Methods
        public CustomHttpClient() => _client = new HttpClient();
        public void Configure(IConfiguration configuration) => _client.DefaultRequestHeaders.Add("X-Api-Key", "498cafbe-8c34-4714-903d-53a33a457da6");
        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content) => _client.PostAsync(requestUri, content);
        public void Dispose() => _client?.Dispose();
        #endregion
    }
}