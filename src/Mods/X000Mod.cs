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
    /// <summary>A base speed <see cref="Mod"/>.</summary>
    public abstract class X000Mod : Mod
    {
        /// <summary>The speed multiplier to apply to the song.</summary>
        public float Speed { get; internal set; }

        /// <summary>
        /// Applies the <see cref="Mod"/> to the <see cref="Gamemode"/>.
        /// </summary>
        /// <param name="gamemode">The <see cref="Gamemode"/> to apply the <see cref="Mod"/> to.</param>
        public sealed override void Apply(Gamemode gamemode)
        {
            Cheat = false;
            ApplyDefaults();
            gamemode.Speed = Speed;
        }

        internal abstract void ApplyDefaults();
    }
}
