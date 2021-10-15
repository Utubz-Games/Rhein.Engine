/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections;

namespace Rhein.Gameplay.Mania
{
    /// <summary>
    /// A <see cref="Gamemodes.Mania"/> <see cref="Lane"/> that provides data about the <see cref="ManiaNote"/>s it holds.
    /// </summary>
    public class Lane
    {
        /// <summary>
        /// The <see cref="Lane"/> index in the <see cref="Gamemodes.Mania"/> <see cref="Gamemodes.Gamemode"/>.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// The <see cref="ManiaNote"/>s of the <see cref="Lane"/>.
        /// </summary>
        public ManiaNoteCollection Notes { get; internal set; }
    }
}
