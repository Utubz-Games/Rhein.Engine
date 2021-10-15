/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections.Base
{
    /// <summary>
    /// An implementation of the <see cref="IEnumerator{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of the value the <see cref="Enumerator{T}"/> will hold.</typeparam>
    public class Enumerator<T> : IEnumerator<T>
    {
        private Collection<T> collection;
        private int index;

        /// <summary>
        /// The current object.
        /// </summary>
        public T Current => collection[index];

        object IEnumerator.Current => collection[index];

        /// <summary>
        /// Moves to the next object of the <see cref="Collection{T}"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the <see cref="Enumerator{T}"/> moved successfully, <see langword="false"/> if it reached the end.</returns>
        public bool MoveNext()
        {
            index++;
            return index < collection.Count - 1;
        }

        /// <summary>
        /// Resets the <see cref="Enumerator{T}"/> back to the beginning.
        /// </summary>
        public void Reset()
        {
            index = 0;
        }

        /// <summary>
        /// Cleans up any resources from the <see cref="Enumerator{T}"/> to prepare for garbage collection.
        /// </summary>
        public void Dispose()
        {
            
        }

        internal Enumerator(Collection<T> collection)
        {
            this.collection = collection;
        }

        internal Enumerator(ReadOnlyCollection<T> collection)
        {
            this.collection = (Collection<T>)(ICollection<T>)collection;
        }
    }
}
