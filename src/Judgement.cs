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

namespace Rhein
{
    /// <summary>
    /// <see cref="Judgement"/>s used to tell the player how accurate they are.
    /// </summary>
    public enum Judgement
    {
        /// <summary>Miss.</summary>
        Miss,
        /// <summary>Okay.</summary>
        Okay,
        /// <summary>Good.</summary>
        Good,
        /// <summary>Great.</summary>
        Great,
        /// <summary>Perfect.</summary>
        Perfect,
        /// <summary>Marvelous.</summary>
        Marvelous
    }
}
