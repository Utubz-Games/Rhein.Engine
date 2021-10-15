/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein;
using Rhein.Gamemodes;
using Rhein.Gameplay;

namespace Rhein.Charting
{
    /// <summary>
    /// A <see cref="Note"/> to be used for making or loading <see cref="Chart"/>s.
    /// </summary>
    public class ChartNote : Note
    {
        /// <summary>
        /// Creates a new <see cref="ChartNote"/> instance.
        /// </summary>
        public ChartNote()
        {

        }

        /// <summary>
        /// Creates a new <see cref="ChartNote"/> instance.
        /// </summary>
        public ChartNote(int type, float beat, float length)
        {
            Type = type;
            Beat = beat;
            Length = length;
        }
    }
}
