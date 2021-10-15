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
    /// A <see cref="Note"/> that provides timing data.
    /// </summary>
    public abstract class Note : RheinObject
    {
        /// <summary>
        /// The beat that the <see cref="Note"/> should be hit on.
        /// </summary>
        public float Beat { get; internal set; }

        /// <summary>
        /// Gets if the <see cref="Note"/> has been hit yet.
        /// </summary>
        public bool Hit { get; internal set; }
    }
}
