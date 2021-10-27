/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
*/

using Rhein.Gamemodes;

namespace Rhein.Mods
{
    /// <summary>A custom speed <see cref="Mod"/>.</summary>
    public class X999Mod : X000Mod
    {
        internal override void ApplyDefaults()
        {
            Type = 25;
        }

        /// <summary>
        /// Creates a custom speed <see cref="Mod"/>.
        /// </summary>
        /// <param name="speed">The speed multiplier to use during gameplay.</param>
        public X999Mod(float speed)
        {
            Speed = speed;
            ApplyDefaults();
        }
    }
}
