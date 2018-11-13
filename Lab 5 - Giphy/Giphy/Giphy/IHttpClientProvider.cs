using System.Net.Http;

namespace Giphy
{
    public interface IHttpClientProvider
    {
        HttpClient Create();
    }
}