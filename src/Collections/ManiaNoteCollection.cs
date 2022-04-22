/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections.Base;
using Rhein.Gameplay;

namespace Rhein.Collections
{
    /// <summary>
    /// A class that separates <see cref="GenericNoteCollection"/> into individual lanes of <see cref="Note"/>s.
    /// </summary>
    public class ManiaNoteCollection
    {
        public int Lanes { get; }
        public GenericNoteCollection[] Notes { get; }

        public void Add(Note note)
            => Notes[note.Type].Enqueue(note);

        public void Remove(int lane)
            => Notes[lane].TryRemove();

        public bool Peek(int lane, out Note note)
            => Notes[lane].TryPeek(out note);

        public ManiaNoteCollection(int lanes)
        {
            Lanes = lanes;
            Notes = new GenericNoteCollection[lanes];
            for (int i = 0; i < lanes; i++)
                Notes[i] = new GenericNoteCollection();
        }

        public ManiaNoteCollection(int lanes, GenericNoteCollection notes)
        {
            Lanes = lanes;
            Notes = new GenericNoteCollection[lanes];
            for (int i = 0; i < lanes; i++)
                Notes[i] = new GenericNoteCollection();

            foreach (Note note in notes)
            {
                Notes[note.Type].Enqueue(note);
            }
        }
    }
}
