/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections.Base;
using Rhein.Gameplay.Mania;

namespace Rhein.Collections
{
    /// <summary>
    /// A <see cref="Collection{T}"/> of <see cref="Lane"/>s.
    /// </summary>
    public class LaneCollection : Collection<Lane>
    {
        /// <summary>
        /// Creates a <see cref="LaneCollection"/> instance with the specified amount of lanes.
        /// </summary>
        /// <param name="amount">The amount of lanes to create.</param>
        public LaneCollection(int amount)
        {
            arr = new Lane[amount];

            for (int i = 0; i < amount; i++)
            {
                Lane lane = new Lane();
                lane.Index = i;
                lane.Notes = new ManiaNoteCollection();
                arr[i] = lane;
            }
        }
    }
}
