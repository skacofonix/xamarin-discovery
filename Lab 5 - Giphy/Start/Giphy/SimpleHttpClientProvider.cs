using System.Net.Http;

namespace Giphy
{
    public class SimpleHttpClientProvider : IHttpClientProvider
    {
        public HttpClient Create() => new HttpClient(new HttpClientHandler());
    }
}