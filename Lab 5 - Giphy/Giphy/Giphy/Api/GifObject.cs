using Newtonsoft.Json;

namespace Giphy.Api
{
    public class GifObject
    {
        [JsonProperty("data")]
        public Datum data { get; set; }
        [JsonProperty("meta")]
        public Meta meta { get; set; }
        [JsonProperty("pagination")]
        public Pagination pagination { get; set; }
    }
}