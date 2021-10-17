/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections.Base
{
    /// <summary>
    /// An implementation of the <see cref="IReadOnlyCollection{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the value the <see cref="ReadOnlyCollection{T}"/> will hold.</typeparam>
    public class ReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        private readonly T[] arr;

        /// <summary>
        /// The amount of items in the <see cref="ReadOnlyCollection{T}"/>.
        /// </summary>
        public int Count => arr.Length;
        /// <summary>
        /// Gets if the <see cref="ReadOnlyCollection{T}"/> is read-only. This should always be <see langword="true"/>.
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        /// Gets a value at the specified index.
        /// </summary>
        /// <param name="index">The index to look at.</param>
        /// <returns>The value at the specified index if index is within range, otherwise an error will be thrown.</returns>
        public T this[int index] { get { return arr[index]; } }

        /// <summary>
        /// Copies the values of the <see cref="ReadOnlyCollection{T}"/> to the <see cref="Array"/>.
        /// </summary>
        /// <param name="array">The <see cref="Array"/> to copy to.</param>
        /// <param name="index">The index to start copying at.</param>
        public void CopyTo(T[] array, int index)
        {
            arr.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the non-generic <see cref="IEnumerator"/> of the <see cref="ReadOnlyCollection{T}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/> of the <see cref="ReadOnlyCollection{T}"/>.</returns>
        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        /// <summary>
        /// Gets if the <see cref="ReadOnlyCollection{T}"/> contains the specified item.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>If the <see cref="ReadOnlyCollection{T}"/> contains the specified item, <see langword="true"/>, otherwise <see langword="false"/>.</returns>
        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        /// <summary>
        /// Gets the index of the specified item.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>The index if found, -1 if not found.</returns>
        public int IndexOf(T item)
        {
            return Array.IndexOf(arr, item);
        }

        /// <summary>
        /// Gets the generic <see cref="IEnumerator{T}"/> of the <see cref="Collection{T}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator{T}"/> of the <see cref="Collection{T}"/>.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        internal ReadOnlyCollection()
        {
            arr = Array.Empty<T>();
        }

        internal ReadOnlyCollection(IEnumerable<T> e)
        {
            ICollection<T> c = (ICollection<T>)e;
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

                using (IEnumerator<T> en = e.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        T[] newArr = new T[arr.Length + 1];
                        Array.Copy(newArr, arr, arr.Length);
                        arr = newArr;
                        arr[arr.Length - 1] = en.Current;
                    }
                }
            }
        }
    }
}
