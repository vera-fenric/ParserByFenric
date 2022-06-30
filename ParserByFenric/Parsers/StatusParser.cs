using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Model;
using ModelJSON;

namespace Parsers
{

    public class StatusParsers
    {

        static public List<string> ParseStatusToStringList(StreamReader sr)
        {
            List<string> list = new List<string>();

            StatusList l = JsonConvert.DeserializeObject<PipelinesJSON>(sr.ReadToEnd());

            foreach (Status s in l)
                list.Add(s.ToString());
            return list;
        }

        static public StatusList ParseStatusToStatusList(StreamReader sr)
        {
            return JsonConvert.DeserializeObject<PipelinesJSON>(sr.ReadToEnd());
        }
    }
}