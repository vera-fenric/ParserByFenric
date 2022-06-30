using ModelJSON;

namespace Model
{
    public class Status : BaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int pipeline_id { get; set; }
        public string color { get; set; }
        public int type { get; set; }

        override public string ToString()
        {
            if (color == null)
                return $"{id},{name},{pipeline_id},null,{type}";
            else
                return $"{id},{name},{pipeline_id},{color},{type}";
        }
        public static implicit operator Status(StatusJSON item)
        {
            return new Status { id = item.id, name = item.name, pipeline_id = item.pipeline_id, color = item.color, type = item.type};
        }

    }

    public class StatusList : BaseList<Status>
    {
        public static implicit operator StatusList(PipelinesJSON statusjson)
        {
            StatusList statuslist = new StatusList();
            foreach (StatusJSON status in statusjson.ToList())
                statuslist.Add(status);
            return statuslist;
        }
    }
}
