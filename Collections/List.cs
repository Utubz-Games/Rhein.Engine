
using System;
using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections
{
    /// <summary>A list of elements.</summary>
    public class List<T> : IEnumerable<T>, ICloneable
    {
        private readonly System.Collections.Generic.List<T> __list = new System.Collections.Generic.List<T>();
        /// <summary>The internal implementation of the list.</summary>
        public System.Collections.Generic.List<T> Internal => __list;

        /// <summary>The number of elements within the list.</summary>
        public int Count => __list.Count;
        /// <summary>The amount of elements the list can hold without allocating more memory.</summary>
        public int Capacity { get => __list.Capacity; set => __list.Capacity = value; }

        /// <summary>Adds a mod to the list.</summary>
        public void Add(T element)
            => __list.Add(element);
        /// <summary>Adds a mod to the list.</summary>
        public void Add(Type type)
            => __list.Add((T)Activator.CreateInstance(type));
        /// <summary>Adds a mod to the list.</summary>
        public void Add<T1>() where T1 : T
            => __list.Add(Activator.CreateInstance<T1>());
        /// <summary>Adds a collection of mods to the list.</summary>
        public void Add(IEnumerable<T> element)
            => __list.AddRange(element);

        /// <summary>Removes a mod to the list.</summary>
        public void Remove(T element)
            => __list.Remove(element);
        /// <summary>Removes a mod to the list.</summary>
        public void Remove(Type type)
            => __list.RemoveAll(elem => elem.GetType() == type);
        /// <summary>Removes a mod to the list.</summary>
        public void Remove<T1>() where T1 : T
            => __list.RemoveAll(elem => elem.GetType() == typeof(T));

        /// <summary>Gets if the list contains a mod.</summary>
        public bool Contains(T element)
            => __list.Contains(element);
        /// <summary>Gets if the list contains a mod.</summary>
        public bool Contains(Type type)
            => __list.FindIndex(mod => mod.GetType() == type) >= 0;
        /// <summary>Gets if the list contains a mod.</summary>
        public bool Contains<T1>() where T1 : T
            => __list.FindIndex(elem => elem.GetType() == typeof(T1)) >= 0;

        /// <summary>Clears all mods from the list.</summary>
        public void Clear()
            => __list.Clear();

        /// <inheritdoc/>
        public T this[int index] { get => __list[index]; set => __list[index] = value; }

        #region IEnumerable

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return __list.GetEnumerator();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return __list.GetEnumerator();
        }


        #endregion

        #region ICloneable

        /// <inheritdoc/>
        public object Clone()
        {
            List<T> list = new List<T>();

            if (Count == 0)
                return list;

            if (list[0] is ICloneable)
            {
                list.Capacity = Count;
                for (int i = 0; i < Count; i++)
                    list[i] = (T)((ICloneable)__list[i]).Clone();
                return list;
            }

            list.Add(__list);
            return list;
        }

        #endregion
    }
}
