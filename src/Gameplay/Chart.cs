﻿/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections;

namespace Rhein.Gameplay
{
    /// <summary>
    /// The base class for all <see cref="Chart"/>s.
    /// </summary>
    public class Chart<T> : IChart where T : Note
    {
        /// <summary>
        /// The type ID of the <see cref="Chart"/>.
        /// </summary>
        public int Type { get; internal set; }
        /// <summary>
        /// The Beats Per Minute of the <see cref="Chart"/>.
        /// </summary>
        public float Bpm { get; internal set; }
        /// <summary>
        /// The Offset in milliseconds of the <see cref="Chart"/>.
        /// </summary>
        public int Offset { get; internal set; }
        /// <summary>
        /// Gets the range of note types in the current collection. Can be used as the Key amount in <see cref="Gamemodes.Mania"/>.
        /// </summary>
        public int TypeRange { get; internal set; }
        /// <summary>
        /// A collection of base <see cref="Note"/>s used in the <see cref="Chart"/>.
        /// </summary>
        public GenericNoteCollection Notes { get; internal set; }
        /// <summary>
        /// A collection of base <see cref="Event"/>s used in the <see cref="Chart"/>.
        /// </summary>
        public GenericEventCollection Events { get; internal set; }

        internal void AddNote(Note note) => AddNote(note as T);
        internal void AddNote(T note) => Notes.Enqueue(note);
        internal void AddEvent(Event ev) => Events.Add(ev);

        void IChart.AddNote(Note note)
        {
            AddNote(note);
        }

        void IChart.AddEvent(Event ev)
        {
            AddEvent(ev);
        }
    }
}
