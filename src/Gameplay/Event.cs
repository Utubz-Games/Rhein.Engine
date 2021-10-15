/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhein.Gameplay
{
    /// <summary>
    /// The base class for all <see cref="Event"/>s.
    /// </summary>
    public abstract class Event
    {
        /// <summary>
        /// The type ID of the <see cref="Event"/>.
        /// </summary>
        public int Type { get; internal set; }

        /// <summary>
        /// The beat that the <see cref="Event"/> should be run on.
        /// </summary>
        public float Beat { get; internal set; }

        /// <summary>
        /// The value of the <see cref="Event"/> for variation.
        /// </summary>
        public object Value { get; internal set; }

        /// <summary>
        /// Gets if the <see cref="Event"/> has ran yet.
        /// </summary>
        public bool Executed { get; internal set; }
    }
}
