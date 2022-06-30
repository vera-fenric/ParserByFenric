using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Model;
using ModelJSON;

namespace Parsers
{

    public class TagsParsers
    {
        
        static public List<string> ParseTagsToStringList(StreamReader sr)
        {
            List<string> list = new List<string>();

            TagList tl = JsonConvert.DeserializeObject<TagsJSON>(sr.ReadToEnd());

            foreach (Tag t in tl)
                list.Add(t.ToString());
            return list;
        }

        static public TagList ParseTagsToTagList(StreamReader sr)
        {
            return JsonConvert.DeserializeObject<TagsJSON>(sr.ReadToEnd());
        }
    }
}