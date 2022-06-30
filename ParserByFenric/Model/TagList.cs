using ModelJSON;

namespace Model
{
    public class Tag: BaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }

        override public string ToString()
        {
            if (color == null)
                return $"{id},{name},null";
            else
                return $"{id},{name},{color}";
        }
        public static implicit operator Tag(TagJSON item)
        {
            return new Tag { id = item.id, name = item.name, color = item.color };
        }

    }

    public class TagList: BaseList<Tag>
    {
        public static implicit operator TagList(TagsJSON tagsjson)
        {
                TagList taglist = new TagList();
                foreach (TagJSON tag in tagsjson.ToList())
                    taglist.Add(tag);
                return taglist;
         }
    }
}
