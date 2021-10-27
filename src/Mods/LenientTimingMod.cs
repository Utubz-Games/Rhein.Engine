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
    /// <summary>A lenient <see cref="TimingWindows"/> <see cref="Mod"/>.</summary>
    public class LenientTimingMod : Mod
    {
        /// <summary>
        /// Applies the <see cref="Mod"/> to the <see cref="Gamemode"/>.
        /// </summary>
        /// <param name="gamemode">The <see cref="Gamemode"/> to apply the <see cref="Mod"/> to.</param>
        public override void Apply(Gamemode gamemode)
        {
            Type = 1;
            Cheat = false;
            gamemode.Windows = TimingWindows.Lenient;
        }
    }
}
