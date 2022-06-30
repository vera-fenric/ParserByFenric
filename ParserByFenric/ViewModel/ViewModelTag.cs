using System;
using System.IO;
using Parsers;
using Model;

namespace ViewModel
{
    public class ViewModelTag : ViewModelBase<Tag>
    {
        public ViewModelTag(IUIServices svc)
        {
            Saved = true;
            UI = svc;
            InputFiles = new BaseList<string>();
            ResultList = new TagList();
            firstLine = "id,name,color";
        }
        public override void Parse()
        {
            foreach (string s in InputFiles)
            {
                try
                {
                    StreamReader sr = new StreamReader(s);
                    ResultList.Add(TagsParsers.ParseTagsToTagList(sr));
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Error(ex.Message, "Ошибка при чтении файла: " + s + ".");
                }
            }
            Saved = false;
        }
    }
}
