/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Mods;

namespace Rhein.Gamemodes
{
    /// <summary>
    /// The 4 Key version of the <see cref="Mania"/> gamemode.
    /// </summary>
    public class Mania4k : Mania
    {
        /// <summary>
        /// The amount of keys used in the current <see cref="Mania4k"/> <see cref="Gamemode"/>. This number should always be 4.
        /// </summary>
        public override int Keys => 4;
    }
}
