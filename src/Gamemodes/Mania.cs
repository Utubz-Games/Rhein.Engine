/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections;
using Rhein.Gameplay;

namespace Rhein.Gamemodes
{
    /// <summary>
    /// An abstract <see cref="Mania"/> <see cref="Gamemode"/> class to be implemented by your own <see cref="Mania"/> gamemodes.
    /// </summary>
    public abstract class Mania : Gamemode<Note>
    {
        /// <summary>
        /// The amount of keys used in the current <see cref="Mania"/> <see cref="Gamemode"/>.
        /// </summary>
        public abstract int Keys { get; }
        /// <summary>
        /// The notes used in the <see cref="Mania"/> <see cref="Gamemode{T}"/>.
        /// </summary>
        public ManiaNoteCollection Notes { get; internal set; }

        internal override void Setup()
        {
            Chart = new Chart<Note>();
            Chart.Notes = new GenericNoteCollection();
            Notes = new ManiaNoteCollection(Keys, Chart.Notes);
        }

        internal override void Start()
        {
            
        }

        internal override void Update()
        {
            
        }
    }
}
