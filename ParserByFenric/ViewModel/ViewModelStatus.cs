using System;
using System.IO;
using Parsers;
using Model;

namespace ViewModel
{
    public class ViewModelStatus : ViewModelBase<Status>
    {
        public ViewModelStatus(IUIServices svc)
        {
            Saved = true;
            UI = svc;
            InputFiles = new ObservableList<string>();
            ResultList = new StatusList();
            firstLine = "id,name,pipeline_id,color,type";
        }
        public override void Parse()
        {
            foreach (string s in InputFiles)
            {
                try
                {
                    StreamReader sr = new StreamReader(s);
                    ResultList.Add(Parser.ParseStatus(sr));
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
