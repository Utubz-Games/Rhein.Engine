/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

namespace Rhein.Gameplay.Mania
{
    /// <summary>
    /// A <see cref="ManiaNote"/> that provides timing data.
    /// </summary>
    public class ManiaNote : Note
    {
        /// <summary>
        /// The <see cref="Mania.Lane"/> the <see cref="ManiaNote"/> is in.
        /// </summary>
        public Lane Lane { get; internal set; }

        /// <summary>
        /// The index of the <see cref="Mania.Lane"/> the <see cref="ManiaNote"/> is in.
        /// </summary>
        public int LaneIndex => Lane.Index;
    }
}
