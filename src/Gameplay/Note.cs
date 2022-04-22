/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Gamemodes;

namespace Rhein.Gameplay
{
    /// <summary>
    /// A base <see cref="Note"/> class that provides basic timing data.
    /// </summary>
    public class Note : RheinObject
    {
        /// <summary>
        /// The type ID of the <see cref="Note"/>.
        /// </summary>
        public int Type { get; internal set; }

        /// <summary>
        /// The beat that the <see cref="Note"/> should be hit on.
        /// </summary>
        public float Beat { get; internal set; }

        /// <summary>
        /// The length in beats that the <see cref="Note"/> should be held for.
        /// </summary>
        public float Length { get; internal set; }

        /// <summary>
        /// Gets if the <see cref="Note"/> has been hit yet.
        /// </summary>
        public bool Calculated { get; internal set; }

        /// <summary>
        /// Gets if the <see cref="Note"/> has been hit/missed yet.
        /// </summary>
        public bool Destroyed { get; internal set; }

        /// <summary>
        /// Gets the time in seconds off the note was hit by.
        /// </summary>
        public float Deviance { get; internal set; }

        /// <summary>
        /// Gets the expected deviance if the note were to be hit right now.
        /// </summary>
        public float Expected { get => (Gamemode.Beat - Beat) * Beat2Sec(); }

        private float Beat2Sec()
            => 60f / Gamemode.Bpm;

        /// <summary>
        /// Sets <see cref="Destroyed"/> to true.
        /// </summary>
        public void Destroy()
        {
            if (Destroyed)
                return;

            Remove();
            Destroyed = true;
        }

        /// <summary>
        /// Hits the <see cref="Note"/> and calculates the deviation from the beat.
        /// </summary>
        public void Hit()
        {
            if (Calculated)
                return;

            Remove();
            Calculated = true;
            Deviance = Expected;
        }

        protected void Remove()
        {
            if (!Calculated && !Destroyed)
                Gamemode.As<Mania>().Notes.Remove(Type);
        }

        /// <summary>
        /// Creates a new <see cref="Note"/> instance.
        /// </summary>
        public Note()
        {
            Type = 0;
            Beat = 0f;
            Length = 0f;
            Calculated = false;
            Destroyed = false;
            Deviance = 0f;
        }

        /// <summary>
        /// Creates a new <see cref="Note"/> instance.
        /// </summary>
        public Note(BaseGamemode gamemode)
        {
            Gamemode = gamemode;
            Type = 0;
            Beat = 0f;
            Length = 0f;
            Calculated = false;
            Destroyed = false;
            Deviance = 0f;
        }

        /// <summary>
        /// Creates a new <see cref="Note"/> instance with the provided parameters.
        /// </summary>
        public Note(BaseGamemode gamemode, int type, float beat, float length)
        {
            Gamemode = gamemode;
            Type = type;
            Beat = beat;
            Length = length;
            Calculated = false;
            Destroyed = false;
            Deviance = 0f;
        }
    }
}
