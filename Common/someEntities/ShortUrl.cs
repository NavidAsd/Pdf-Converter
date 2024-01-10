
using Newtonsoft.Json;

namespace Common.someEntities
{
    public class ShortUrl
    {
        [JsonProperty("hash")]
        public string hash { set; get; }
        [JsonProperty("short_url")]
        public string short_url { set; get; }
    }
}
