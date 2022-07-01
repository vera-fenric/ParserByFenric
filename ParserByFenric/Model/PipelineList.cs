using ModelJSON;

namespace Model
{
    public class Pipeline : BaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int sort { get; set; }
        public bool is_main { get; set; }
        public bool is_unsorted_on { get; set; }
        public bool is_archive { get; set; }
        override public string ToString()
        {
            return $"{id},{name},{sort},{is_main},{is_unsorted_on},{is_archive}";
        }
        public static implicit operator Pipeline(PipelineJSON item)
        {
            return new Pipeline { id = item.id, name = item.name, sort = item.sort, is_main = item.is_main, is_unsorted_on = item.is_unsorted_on, is_archive = item.is_archive };
        }

    }

    public class PipelineList : ObservableList<Pipeline>
    {
        public static implicit operator PipelineList(PipelinesJSON json)
        {
            PipelineList list = new PipelineList();
            foreach (PipelineJSON pipeline in json.PipelinesToList())
                list.Add(pipeline);
            return list;
        }
    }
}
