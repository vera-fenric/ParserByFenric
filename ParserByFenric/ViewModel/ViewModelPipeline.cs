using System;
using System.IO;
using Parsers;
using Model;

namespace ViewModel
{
    public class ViewModelPipeline : ViewModelBase<Pipeline>
    {
        public ViewModelPipeline(IUIServices svc)
        {
            Saved = true;
            UI = svc;
            InputFiles = new ObservableList<string>();
            ResultList = new PipelineList();
            firstLine = "id,name,sort,is_main,is_unsorted_on,is_archive";
        }
        public override void Parse()
        {
            foreach (string s in InputFiles)
            {
                try
                {
                    StreamReader sr = new StreamReader(s);
                    ResultList.Add(Parser.ParsePipeline(sr));
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
