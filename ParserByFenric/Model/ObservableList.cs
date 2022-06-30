using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Model
{
    public abstract class BaseObject { }
    public abstract class RegularList<T>: IEnumerable<T>
    {
        private List<T> list;
        public List<T> List
        {
            set
            {
                list = value;
            }
            get => list;
        }
        public RegularList(List<T> list)
        {
            List = new List<T>();
            List.AddRange(list);
        }
        public RegularList()
        {
            List = new List<T>();
        }

        public override string ToString()
        {
            return String.Join("\n", this.ToStringList());
        }
        public List<string> ToStringList()
        {
            List<string> _list = new List<string>();
            foreach (T t in List)
                _list.Add(t.ToString());
            return _list;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)List).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public int Count
        {
            get => List.Count;
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }
    }

    public class BaseList<T> : RegularList<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {


        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void Add(T item)
        {
            if (List.Contains(item))
                return;
            List.Add(item);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public void Add(BaseList<T> list)
        {
            foreach (T item in list)
                if (!List.Contains(item))
                    List.Add(item);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public void AddRange(List<T> list)
        {
            foreach (T item in list)
                if (!List.Contains(item))
                    List.Add(item);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public void Clear()
        {
            List.Clear();
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        public void Remove(T item)
        {
            if (List.Contains(item))
                List.Remove(item);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public void Remove(List<T> list)
        {
            foreach (T item in list)
                if (List.Contains(item))
                    List.Remove(item);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
    }
}
