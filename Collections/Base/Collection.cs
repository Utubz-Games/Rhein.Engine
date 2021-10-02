using System;
using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections.Base
{
    public class Collection<T> : ICollection<T>
    {
        private T[] arr;

        public int Count => arr.Length;
        public bool IsSynchronized => false;
        public object SyncRoot => this;

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] { get { return arr[index]; } set { arr[index] = value; } }

        public void Add(T item)
        {
            T[] newArr = new T[arr.Length + 1];
            Array.Copy(newArr, arr, arr.Length);
            arr = newArr;
            arr[arr.Length - 1] = item;
        }

        public void Add(IEnumerable<T> items)
        {
            ICollection<T> c = (ICollection<T>)items;
            if (c != null)
            {
                if (c.Count == 0)
                {
                    arr = Array.Empty<T>();
                } else
                {
                    arr = new T[c.Count];
                    c.CopyTo(arr, 0);
                }
            } else
            {
                arr = Array.Empty<T>();

                using (IEnumerator<T> en = items.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Add(en.Current);
                    }
                }
            }
        }

        public void CopyTo(T[] array, int index)
        {
            arr.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        public void Clear()
        {
            arr = Array.Empty<T>();
        }

        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(arr, item);
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        internal Collection()
        {
            arr = Array.Empty<T>();
        }

        internal Collection(IEnumerable<T> e)
        {
            Add(e);
        }
    }
}
