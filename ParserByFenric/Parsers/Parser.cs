using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Model;
using ModelJSON;

namespace Parsers
{
    //не используется------------------------------------------------------------------------------------
    public class Parser
    {
        static public List<string> ParseTagToString(StreamReader sr)
        {
            List<string> list = new List<string>();

            TagList tl = JsonConvert.DeserializeObject<TagsJSON>(sr.ReadToEnd());

            foreach (Tag t in tl)
                list.Add(t.ToString());
            return list;
        }

        static public TagList ParseTag(StreamReader sr)
        {
            return JsonConvert.DeserializeObject<TagsJSON>(sr.ReadToEnd());
        }

        static public List<string> ParseStatusToString(StreamReader sr)
        {
            List<string> list = new List<string>();

            StatusList l = JsonConvert.DeserializeObject<PipelinesJSON>(sr.ReadToEnd());

            foreach (Status s in l)
                list.Add(s.ToString());
            return list;
        }

        static public StatusList ParseStatus(StreamReader sr)
        {
            return JsonConvert.DeserializeObject<PipelinesJSON>(sr.ReadToEnd());
        }

        static public List<string> ParsePipelineToString(StreamReader sr)
        {
            List<string> list = new List<string>();

            PipelineList l = JsonConvert.DeserializeObject<PipelinesJSON>(sr.ReadToEnd());

            foreach (Pipeline s in l)
                list.Add(s.ToString());
            return list;
        }

        static public PipelineList ParsePipeline(StreamReader sr)
        {
            return JsonConvert.DeserializeObject<PipelinesJSON>(sr.ReadToEnd());
        }

        static public List<string> ParseUserToString(StreamReader sr)
        {
            List<string> list = new List<string>();

            UserList l = JsonConvert.DeserializeObject<UsersJSON>(sr.ReadToEnd());

            foreach (User s in l)
                list.Add(s.ToString());
            return list;
        }

        static public UserList ParseUser(StreamReader sr)
        {
            return JsonConvert.DeserializeObject<UsersJSON>(sr.ReadToEnd());
        }
    }
}