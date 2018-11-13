using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Giphy.Api
{
    public class GiphyClient
    {
        private readonly Uri _baseUri;
        private readonly IHttpClientProvider _httpClientProvider;
        private readonly string _apiKey;

        public GiphyClient(IHttpClientProvider httpClientProvider, string apiKey)
        {
            _baseUri = new Uri("http://api.giphy.com");
            _httpClientProvider = httpClientProvider;
            _apiKey = apiKey;
        }

        public async Task<GifObject> Translate(string search, CancellationToken cancellationToken)
        {
            GifObject output;

            var queryBuilder = new QueryBuilder(_baseUri + "v1/gifs/translate");
            queryBuilder.AddParameter("api_key", _apiKey);
            queryBuilder.AddParameter("s", search);
            var url = queryBuilder.ToString();

            var client = _httpClientProvider.Create();
            var response = await client.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            using (var sr = new StreamReader(stream))
            using (var reader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                output = serializer.Deserialize<GifObject>(reader);
            }

            return output;
        }
    }
}