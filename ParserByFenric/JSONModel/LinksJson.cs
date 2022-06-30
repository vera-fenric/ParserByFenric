using Newtonsoft.Json;

namespace ModelJSON
{
    class LinkJSON
    {
        [JsonProperty("href")]
        string href { get; set; }
    }
    class LinksJSON
    {
        [JsonProperty("self")]
        LinkJSON self { get; set; }
        [JsonProperty("next")]
        LinkJSON next { get; set; }
        [JsonProperty("first")]
        LinkJSON first { get; set; }
        [JsonProperty("prev")]
        LinkJSON prev { get; set; }
    }
}
