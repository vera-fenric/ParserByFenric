using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Model;
using Parsers;

namespace ViewModel
{
    public enum ParseType
    {
        Tag,
        Status,
        Pipeline,
        User
    }
    //ViewModel для привязки ко View
    public abstract class ViewModelRegular
    {
        public abstract void OpenFiles();
        public abstract bool Closing();
        public abstract void Error();
        public abstract void Error(string s);
        public abstract void Error(string s1, string s2);
        public abstract void SaveResults();
        public abstract void Parse();
    }

    public abstract class ViewModelBase<BaseObject> : ViewModelRegular, INotifyPropertyChanged
    {
        protected string firstLine;
        //поля и свойства
        protected IUIServices UI;
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

        protected ObservableList<string> inputFiles;
        public ObservableList<string> InputFiles
        {
            get => inputFiles;
            set
            {
                inputFiles = value;
                NotifyPropertyChanged("InputFiles");
            }
        }

        protected ObservableList<BaseObject> _resultList;
        public ObservableList<BaseObject> ResultList
        {
            get => _resultList;
            set
            {
                _resultList = value;
                NotifyPropertyChanged("ResultList");
            }
        }

        //контролировать изменения свойств для привязки
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //методы
        public override void OpenFiles()
        {
            foreach (string s in UI.OpenFileFunc())
                InputFiles.Add(s);
        }
        
        public override bool Closing()
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
        public override void Error(string s)
        {
            UI.ErrorFunc(s);
        }
        public override void Error()
        {
            UI.ErrorFunc();
        }
        public override void Error(string s1, string s2)
        {
            UI.ErrorFunc(s1, s2);
        }
        public override void SaveResults()
        {
            string filename = UI.SaveFileFunc();
            if (filename != null)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filename, false);
                    sw.WriteLine(firstLine);
                    foreach (BaseObject bo in ResultList)
                        sw.WriteLine(bo);
                    sw.Close();
                    Saved = true;
                }
                catch (Exception ex)
                {
                    Error(ex.Message, "Ошибка при сохранении файла: " + filename + ".");
                }
            }
        }
    }
}