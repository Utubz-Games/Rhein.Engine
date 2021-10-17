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
    /// The base class for all <see cref="Chart"/>s.
    /// </summary>
    public class ManiaChart : Chart
    {
        /// <summary>
        /// The type ID of the <see cref="ManiaChart"/>. This should always be 0.
        /// </summary>
        public new int Type { get; internal set; } = 0;
    }
}
