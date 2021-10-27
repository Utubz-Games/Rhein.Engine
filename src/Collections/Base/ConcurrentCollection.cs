/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
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
    public class ConcurrentCollection<T> : ConcurrentStack<T>
    {
        /// <summary>
        /// Attempts to check to see if the next item from the <see cref="ConcurrentCollection{T}"/> is <see langword="null"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the value is not <see langword="null"/>, otherwise <see langword="false"/>.</returns>
        public bool TryHasNext()
        {
            return !IsEmpty;
        }

        /// <summary>
        /// Attempts to check to see if the next item from the <see cref="ConcurrentCollection{T}"/> is <see langword="null"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the value is not <see langword="null"/>, otherwise <see langword="false"/>.</returns>
        public bool TryNotNull()
        {
            return TryPeek(out T item) && item != null;
        }

        /// <summary>
        /// Attempts to remove the next item from the <see cref="ConcurrentCollection{T}"/>.
        /// </summary>
        /// <returns><see langword="true"/> if the remove was successful, otherwise <see langword="false"/>.</returns>
        public bool TryRemove()
        {
            return TryPop(out _);
        }

        /// <summary>
        /// Creates a new <see cref="Collection{T}"/> instance.
        /// </summary>
        public ConcurrentCollection() : base()
        {
            
        }

        /// <summary>
        /// Creates a new <see cref="Collection{T}"/> instance.
        /// </summary>
        public ConcurrentCollection(IEnumerable<T> e) : base(e)
        {
            
        }
    }
}
