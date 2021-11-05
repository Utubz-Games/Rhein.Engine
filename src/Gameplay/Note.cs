/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhein.Gameplay
{
    /// <summary>
    /// A base <see cref="Note"/> class that provides basic timing data.
    /// </summary>
    public class Note : RheinObject
    {
        /// <summary>
        /// The type ID of the <see cref="Note"/>.
        /// </summary>
        public int Type { get; internal set; }

        /// <summary>
        /// The beat that the <see cref="Note"/> should be hit on.
        /// </summary>
        public float Beat { get; internal set; }

        /// <summary>
        /// The length in beats that the <see cref="Note"/> should be held for.
        /// </summary>
        public float Length { get; internal set; }

        /// <summary>
        /// Gets if the <see cref="Note"/> has been hit yet.
        /// </summary>
        public bool Hit { get; internal set; }

        /// <summary>
        /// Gets if the <see cref="Note"/> has been hit/missed yet.
        /// </summary>
        public bool Destroyed { get; internal set; }

        /// <summary>
        /// Gets the time in seconds off the note was hit by.
        /// </summary>
        public float Deviance { get; internal set; }

        /// <summary>
        /// Sets <see cref="Destroyed"/> to true.
        /// </summary>
        public void Destroy()
        {
            Destroyed = true;
        }

        /// <summary>
        /// Creates a new <see cref="Note"/> instance.
        /// </summary>
        public Note()
        {

        }
    }
}
