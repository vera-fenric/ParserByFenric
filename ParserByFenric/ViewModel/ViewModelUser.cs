using System;
using System.IO;
using Parsers;
using Model;

namespace ViewModel
{
    public class ViewModelUser : ViewModelBase<User>
    {
        public ViewModelUser(IUIServices svc)
        {
            Saved = true;
            UI = svc;
            InputFiles = new ObservableList<string>();
            ResultList = new UserList();
            firstLine = "id,name,email,lang";
        }
        public override void Parse()
        {
            foreach (string s in InputFiles)
            {
                try
                {
                    StreamReader sr = new StreamReader(s);
                    ResultList.Add(Parser.ParseUser(sr));
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
