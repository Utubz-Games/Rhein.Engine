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
    /// <summary>The base class for all <see cref="Mod"/>s.</summary>
    public abstract class Mod
    {
        /// <summary>
        /// The <see cref="Mod"/> ID. Used for online leaderboards.
        /// </summary>
        public int Type { get; internal set; } = -1;
        /// <summary>
        /// Gets if the <see cref="Mod"/> is a cheat <see cref="Mod"/>. By default this is <see langword="true"/> to prevent cheating with unranked <see cref="Mod"/>s.
        /// </summary>
        public bool Cheat { get; internal set; } = true;

        /// <summary>
        /// Applies the <see cref="Mod"/> to the <see cref="Gamemode"/>.
        /// </summary>
        /// <param name="gamemode">The <see cref="Gamemode"/> to apply the <see cref="Mod"/> to.</param>
        public abstract void Apply(BaseGamemode gamemode);
    }
}
