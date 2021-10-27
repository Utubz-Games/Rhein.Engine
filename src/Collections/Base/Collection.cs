/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections.Base
{
    /// <summary>
    /// An implementation of the <see cref="ICollection{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the value the <see cref="Collection{T}"/> will hold.</typeparam>
    public class Collection<T> : ICollection<T>
    {
        protected T[] arr;

        /// <summary>
        /// The amount of items in the <see cref="Collection{T}"/>.
        /// </summary>
        public int Count => arr.Length;
        /// <summary>
        /// Gets if the <see cref="Collection{T}"/> is read-only. This should always be <see langword="false"/>.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets a value at the specified index.
        /// </summary>
        /// <param name="index">The index to look at.</param>
        /// <returns>The value at the specified index if index is within range, otherwise an error will be thrown.</returns>
        public T this[int index] { get { return arr[index]; } set { arr[index] = value; } }

        /// <summary>
        /// Adds an item to the <see cref="Collection{T}"/>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void Add(T item)
        {
            T[] newArr = new T[arr.Length + 1];
            Array.Copy(newArr, arr, arr.Length);
            arr = newArr;
            arr[arr.Length - 1] = item;
        }

        /// <summary>
        /// Adds an item to the <see cref="Collection{T}"/> with the specified amount.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        /// <param name="amount">The amount of times the item will be added.</param>
        public void Add(T item, int amount)
        {
            T[] newArr = new T[arr.Length + amount];
            Array.Copy(newArr, arr, arr.Length);
            arr = newArr;
            
            for (int i = 0; i < amount; i++)
            {
                arr[arr.Length + amount - 1] = item;
            }
        }

        /// <summary>
        /// Adds a <see cref="Collection{T}"/> of items to the <see cref="Collection{T}"/>.
        /// </summary>
        /// <param name="items">The items to add.</param>
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

        /// <summary>
        /// Copies the values of the <see cref="Collection{T}"/> to the <see cref="Array"/>.
        /// </summary>
        /// <param name="array">The <see cref="Array"/> to copy to.</param>
        /// <param name="index">The index to start copying at.</param>
        public void CopyTo(T[] array, int index)
        {
            arr.CopyTo(array, index);
        }

        /// <summary>
        /// Gets the non-generic <see cref="IEnumerator"/> of the <see cref="Collection{T}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/> of the <see cref="Collection{T}"/>.</returns>
        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        /// <summary>
        /// Clears the <see cref="Collection{T}"/>.
        /// </summary>
        public void Clear()
        {
            arr = Array.Empty<T>();
        }

        /// <summary>
        /// Gets if the <see cref="Collection{T}"/> contains the specified item.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns>If the <see cref="Collection{T}"/> contains the specified item, <see langword="true"/>, otherwise <see langword="false"/>.</returns>
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
        /// Removes the specified item from the <see cref="Collection{T}"/>.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>If the item was removed, <see langword="true"/>, otherwise <see langword="false"/>.</returns>
        public bool Remove(T item)
        {
            return Remove(IndexOf(item));
        }

        /// <summary>
        /// Removes the item at the specified index from the <see cref="Collection{T}"/>.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        /// <returns>If the item was removed, <see langword="true"/>, otherwise <see langword="false"/>.</returns>
        public bool Remove(int index)
        {
            if (arr.Length <= 0)
                return false;

            if (index < 0)
                return false;

            if (index >= arr.Length)
                return false;

            Logger.Write($"Current Length: {arr.Length}, New Length: {arr.Length - 1}");
            
            if (index < arr.Length - 1)
                Array.Copy(arr, index + 1, arr, index, arr.Length - index - 1);
            T[] newArr = new T[arr.Length - 1];
            arr = newArr;

            return true;
        }

        /// <summary>
        /// Gets the generic <see cref="IEnumerator{T}"/> of the <see cref="Collection{T}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator{T}"/> of the <see cref="Collection{T}"/>.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        /// <summary>
        /// Creates a new <see cref="Collection{T}"/> instance.
        /// </summary>
        public Collection()
        {
            arr = Array.Empty<T>();
        }

        /// <summary>
        /// Creates a new <see cref="Collection{T}"/> instance.
        /// </summary>
        public Collection(IEnumerable<T> e)
        {
            Add(e);
        }
    }
}
