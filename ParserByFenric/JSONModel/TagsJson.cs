using System.Collections.Generic;
using Newtonsoft.Json;

namespace ModelJSON
{
    //Эти структуры нужны для того, чтобы распарсить файл с тегами
    public class TagJSON: BaseJSONObject
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("color")]
        public string color { get; set; }
        //public string ToStringJSON()
        //{
        //    if (color == null)
        //        return $"{{\"id\":{id},\"name\":\"{name}\",\"color\":null}}";
        //    else
        //        return $"{{\"id\":{id},\"name\":\"{name}\",\"color\":\"{color}\"}}";
        //}
    }
    class EmbeddedTagsJSON
    {
        [JsonProperty("tags")]
        List<TagJSON> tags { get; set; }
        //public override string ToString()
        //{
        //    return String.Join("\n", tags);
        //}

        public List<TagJSON> ToList()
        {
            return tags;
        }
    }
    public class TagsJSON: BaseJSONList<TagJSON>
    {
        [JsonProperty("_page")]
        int page { get; set; }
        [JsonProperty("_links")]
        LinksJSON links { get; set; }
        [JsonProperty("_embedded")]
        EmbeddedTagsJSON embedded { get; set; }
        //public override string ToString()
        //{
        //    return embedded.ToString();
        //}
        public override List<TagJSON> ToList()
        {
            return embedded.ToList();
        }
    }
}
