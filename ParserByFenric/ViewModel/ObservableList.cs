using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ViewModel
{
    //реализация ObservableList для связи с ListBox
    public class ObservableList : IEnumerable<string>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private List<string> filenames;
        public List<string> Filenames
        {
            get => filenames;
            set { filenames = value; }
        }

        public ObservableList()
        {
            Filenames = new List<string>();
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return "InputFiles\n";
        }

        public int Count
        {
            get => Filenames.Count;
        }

        //реализация интерфейса IEnumerable<DataItem>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Filenames).GetEnumerator();
        }
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return Filenames.GetEnumerator();
        }

        public void Add(string item)
        {
            Filenames.Add(item);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public void AddRange(List<string> list)
        {
            foreach (string s in list)
                if (!Filenames.Contains(s))
                    Filenames.Add(s);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public void Clear()
        {
            Filenames.Clear();
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        public bool Contains(string s)
        {
            return Filenames.Contains(s);
        }
    }
}
