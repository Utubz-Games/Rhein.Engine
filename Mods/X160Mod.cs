﻿/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
*/

using Rhein.Gamemodes;

namespace Rhein.Mods
{
    /// <summary>A 1.6x speed <see cref="Mod"/>.</summary>
    public class X160Mod : X000Mod
    {
        internal override void ApplyDefaults()
        {
            Type = 20;
            Speed = 1.6f;
        }
    }
}
