/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Rhein.Collections.Base
{
    /// <summary>
    /// An implementation of the <see cref="IProducerConsumerCollection{T}"/> interface using FILO-style accessors.
    /// </summary>
    /// <typeparam name="T">The type of the value the <see cref="ConcurrentCollection{T}"/> will hold.</typeparam>
    public class ConcurrentCollection<T> : IProducerConsumerCollection<T>
    {
        protected T[] arr;
        private bool accessing;

        /// <summary>
        /// The amount of items in the <see cref="Collection{T}"/>.
        /// </summary>
        public int Count => arr.Length;
        /// <summary>
        /// Gets if the <see cref="Collection{T}"/> is synchronized. This should always be <see langword="false"/>.
        /// </summary>
        public bool IsSynchronized => true;
        /// <summary>
        /// The object to sync to. This should always be equal to <see langword="this"/>.
        /// </summary>
        public object SyncRoot => this;
        /// <summary>
        /// Gets if the <see cref="Collection{T}"/> is read-only. This should always be <see langword="false"/>.
        /// </summary>
        public bool IsReadOnly => false;

        private void StartAccess()
        {
            accessing = true;
        }

        private void EndAccess()
        {
            accessing = false;
        }

        /// <summary>
        /// Attempts to check to see if the next item from the <see cref="ConcurrentCollection{T}"/> is <see langword="null"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the value is not <see langword="null"/>, otherwise <see langword="false"/>.</returns>
        public bool TryNotNull()
        {
            if (accessing || arr.Length <= 0)
                return false;

            StartAccess();
            bool isNotNull = arr[0] != null;
            EndAccess();
            return isNotNull;
        }

        /// <summary>
        /// Attempts to remove the next item from the <see cref="ConcurrentCollection{T}"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the remove was successful, otherwise <see langword="false"/>.</returns>
        public bool TryRemove()
        {
            if (accessing || arr.Length <= 0)
                return false;

            StartAccess();
            Remove(0);
            EndAccess();
            return true;
        }

        /// <summary>
        /// Attemps to look and take the next item from the <see cref="ConcurrentCollection{T}"/>.
        /// </summary>
        /// <param name="item">The item to be taken.</param>
        /// <returns><see langword="true"/> if the take was successful, otherwise <see langword="false"/>.</returns>
        public bool TryTake(out T item)
        {
            if (accessing || arr.Length <= 0)
            {
                item = default;
                return false;
            }

            StartAccess();
            item = arr[0];
            Remove(0);
            EndAccess();
            return true;
        }

        /// <summary>
        /// Attemps to look at the next item of the <see cref="ConcurrentCollection{T}"/>.
        /// </summary>
        /// <param name="item">The item to get.</param>
        /// <returns><see langword="true"/> if the peek was successful, otherwise <see langword="false"/>.</returns>
        public bool TryPeek(out T item)
        {
            if (accessing || arr.Length <= 0)
            {
                item = default;
                return false;
            }

            StartAccess();
            item = arr[0];
            EndAccess();
            return true;
        }

        /// <summary>
        /// Attemps to add an item to the <see cref="ConcurrentCollection{T}"/>.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        /// <returns><see langword="true"/> if the add was successful, otherwise <see langword="false"/>.</returns>
        public bool TryAdd(T item)
        {
            if (accessing || item == null)
                return false;

            StartAccess();
            T[] newArr = new T[arr.Length + 1];
            Array.Copy(newArr, arr, arr.Length);
            arr = newArr;
            arr[arr.Length - 1] = item;
            EndAccess();
            return true;
        }

        private bool Add(T item)
        {
            T[] newArr = new T[arr.Length + 1];
            Array.Copy(newArr, arr, arr.Length);
            arr = newArr;
            arr[arr.Length - 1] = item;
            return true;
        }

        private void Add(T item, int amount)
        {
            T[] newArr = new T[arr.Length + amount];
            Array.Copy(newArr, arr, arr.Length);
            arr = newArr;
            
            for (int i = 0; i < amount; i++)
            {
                arr[arr.Length + amount - 1] = item;
            }
        }

        private void Add(IEnumerable<T> items)
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
                        TryAdd(en.Current);
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
        /// Copies the values of the <see cref="Collection{T}"/> to the <see cref="Array"/>.
        /// </summary>
        /// <param name="array">The <see cref="Array"/> to copy to.</param>
        /// <param name="index">The index to start copying at.</param>
        public void CopyTo(Array array, int index)
        {
            arr.CopyTo(array, index);
        }

        /// <summary>
        /// Converts the collection to a copy of an array.
        /// </summary>
        /// <returns>The copied array.</returns>
        public T[] ToArray()
        {
            T[] newArr = new T[arr.Length];
            CopyTo(newArr, 0);
            return newArr;
        }

        /// <summary>
        /// Gets the non-generic <see cref="IEnumerator"/> of the <see cref="Collection{T}"/>.
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/> of the <see cref="Collection{T}"/>.</returns>
        public IEnumerator GetEnumerator()
        {
            return new Enumerator<T>(arr);
        }

        /// <summary>
        /// Clears the <see cref="Collection{T}"/>.
        /// </summary>
        public void Clear()
        {
            arr = Array.Empty<T>();
        }

        private bool Remove(int index)
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        /// <summary>
        /// Creates a new <see cref="Collection{T}"/> instance.
        /// </summary>
        public ConcurrentCollection()
        {
            arr = Array.Empty<T>();
        }

        /// <summary>
        /// Creates a new <see cref="Collection{T}"/> instance.
        /// </summary>
        public ConcurrentCollection(IEnumerable<T> e)
        {
            Add(e);
        }
    }
}
