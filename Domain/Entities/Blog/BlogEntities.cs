using Newtonsoft.Json;

namespace Domain.Entities.Blog
{
    public class BlogEntities
    {
        [JsonProperty("id")]
        public long Id { set; get; }
        [JsonProperty("date")]
        public string InsertDate { set; get; }
        [JsonProperty("status")]
        public string Status { set; get; }
        [JsonProperty("type")]
        public string Type { set; get; }
        [JsonProperty("title")]
        public string Title { set; get; }
        [JsonProperty("content")]
        public string Content { set; get; }
        [JsonProperty("source_url")]
        public string TitleImage { set; get; }
        [JsonProperty("link")]
        public string Link { set; get; }
    }
}
