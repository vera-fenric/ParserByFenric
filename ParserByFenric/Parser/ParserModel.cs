using System;
using System.Collections.Generic;
using System.IO;

namespace ParserModel
{
    //собственно, сам парсер (можно сделать лучше, но зачем, если и так работает?)
    public class Parser
    {
        public List<string> ParseTags(StreamReader sr)
        {
            List<string> list = new List<string>();
            const string search_string = "_embedded";
            string s = sr.ReadLine();
            int index = s.IndexOf(search_string);
            if (index > 0)
                s = s.Substring(index + search_string.Length + 11, s.Length - index - search_string.Length - 14);
            int start_index = s.IndexOf("{");
            int end_index = s.IndexOf("}");
            string s2;
            while (start_index >= 0)
            {
                if (end_index < start_index)
                    throw new Exception("Некорректный файл");
                {
                    s2 = s.Substring(start_index + 1, end_index - start_index - 1);
                    int index_of_comma = s2.IndexOf(",");
                    s2 = s2.Substring(5, index_of_comma - 5) + "," + s2.Substring(index_of_comma + 9, s2.Length - 10 - index_of_comma);
                }
                if (end_index != s.Length)
                    s = s.Substring(end_index + 1);
                else
                    s = "";
                list.Add(s2);
                start_index = s.IndexOf("{");
                end_index = s.IndexOf("}");
            }
            return list;
        }
    }
}
