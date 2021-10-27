/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein;
using Rhein.Gamemodes;

namespace Rhein
{
    /// <summary>
    /// The base class for most <see cref="Rhein"/> Engine classes.
    /// </summary>
    public abstract class RheinObject
    {
        internal Gamemode Gamemode { get; set; }
    }
}
