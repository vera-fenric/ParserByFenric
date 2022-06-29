using ParserModel;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    //ViewModel для привязки ко View
    public class ParserViewModel : INotifyPropertyChanged
    {
        //конструктор
        public ParserViewModel(IUIServices svc)
        {
            Saved = true;
            UI = svc;
            parser = new Parser();
            Input_files = new ObservableList();
            Result = new ObservableList();
        }

        //поля и свойства

        private readonly IUIServices UI;
        private bool _saved;
        public bool Saved
        {
            get => _saved;
            set
            {
                _saved = value;
                NotifyPropertyChanged();
            }
        }
        private ObservableList _result;
        public ObservableList Result
        {
            get => _result;
            set
            {
                _result = value;
                NotifyPropertyChanged();
            }
        }
        protected Parser parser;
        protected ObservableList input_files;
        public ObservableList Input_files
        {
            get => input_files;
            set
            {
                input_files = value;
                NotifyPropertyChanged("Input_files");
            }
        }

        //контролировать изменения свойств для привязки
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //методы
        public void OpenFiles()
        {
            foreach (string s in UI.OpenFileFunc())
                Input_files.Add(s);
        }
        public void SaveResults()
        {
            string filename = UI.SaveFileFunc();
            if (filename != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filename, false);
                    foreach (string s in Result)
                        sw.WriteLine(s);
                    sw.Close();
                    Saved = true;
                }
                catch (Exception ex)
                {
                    Error(ex.Message, "Ошибка при сохранении файла: " + filename + ".");
                }
            }
        }
        public void ParseTags()
        {
            if (!Result.Contains("id,name"))
                Result.Add("id,name");
            foreach (string s in Input_files)
            {
                try
                {
                    StreamReader sr = new StreamReader(s);
                    Result.AddRange(parser.ParseTags(sr));
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Error(ex.Message, "Ошибка при чтении файла: " + s + ".");
                }
            }
            Saved = false;
        }
        public bool Closing()
        {
            if (Saved)
                return false;
            YNC ync = UI.ConfirmFunc("Сохранить изменения?");
            switch (ync)
            {
                case YNC.Yes:
                    this.SaveResults();
                    return false;
                case YNC.No:
                    return false;
                case YNC.Cancel:
                    return true;
                default:
                    return false;
            }
        }
        public void Error(string s)
        {
            UI.ErrorFunc(s);
        }
        public void Error()
        {
            UI.ErrorFunc();
        }
        public void Error(string s1, string s2)
        {
            UI.ErrorFunc(s1, s2);
        }

    }
}
