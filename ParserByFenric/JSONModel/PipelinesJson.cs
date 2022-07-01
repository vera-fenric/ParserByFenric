using System.Collections.Generic;
using Newtonsoft.Json;

namespace ModelJSON
{
    //Эти структуры нужны для того, чтобы распарсить файл с тегами
    public class StatusJSON: BaseJSONObject
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("sort")]
        public int sort { get; set; }

        [JsonProperty("is_editable")]
        public bool is_editable { get; set; }

        [JsonProperty("pipeline_id")]
        public int pipeline_id { get; set; }

        [JsonProperty("color")]
        public string color { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("account_id")]
        public int account_id { get; set; }
        [JsonProperty("_links")]
        LinksJSON links { get; set; }
    }

    class EmbeddedStatusesJSON
    {
        [JsonProperty("statuses")]
        List<StatusJSON> statuses { get; set; }

        public List<StatusJSON> ToList()
        {
            return statuses;
        }
    }
    public class PipelineJSON
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("sort")]
        public int sort { get; set; }

        [JsonProperty("is_main")]
        public bool is_main { get; set; }

        [JsonProperty("is_unsorted_on")]
        public bool is_unsorted_on { get; set; }

        [JsonProperty("is_archive")]
        public bool is_archive { get; set; }

        [JsonProperty("account_id")]
        public int account_id { get; set; }

        [JsonProperty("_links")]
        LinksJSON _links { get; set; }
        [JsonProperty("_embedded")]
        EmbeddedStatusesJSON _embedded { get; set; }

        public List<StatusJSON> ToList()
        {
            return _embedded.ToList();
        }
    }

    class EmbeddedPipelinesJSON
    {
        [JsonProperty("pipelines")]
        List<PipelineJSON> pipelines { get; set; }

        public List<PipelineJSON> PipelinesToList()
        {
            return pipelines;
        }
        public List<StatusJSON> ToList()
        {
            List<StatusJSON> list = new List<StatusJSON>();
            foreach (PipelineJSON pipeline in pipelines)
                list.AddRange(pipeline.ToList());
            return list;
        }
    }
    public class PipelinesJSON : BaseJSONList<StatusJSON>
    {
        [JsonProperty("_total_items")]
        int _total_items { get; set; }

        [JsonProperty("_links")]
        LinksJSON _links { get; set; }

        [JsonProperty("_embedded")]
        EmbeddedPipelinesJSON _embedded { get; set; }

        public override List<StatusJSON> ToList()
        {
            return _embedded.ToList();
        }
        public List<PipelineJSON> PipelinesToList()
        {
            return _embedded.PipelinesToList();
        }
    }
}
