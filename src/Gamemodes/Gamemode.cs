/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Mods;
using Rhein.Gameplay;
using Rhein.Gameplay.Mania;
using System.Diagnostics;

namespace Rhein.Gamemodes
{
    /// <summary>
    /// An abstract <see cref="Gamemode"/> to implement your own gameplay styles.
    /// This class contains everything related to current gameplay.
    /// </summary>
    public abstract class Gamemode
    {
        private int pastBeat;
        private bool playing;

        /// <summary>
        /// The current <see cref="Gameplay.Chart"/> being used for this <see cref="Gamemode"/>.
        /// </summary>
        public Chart Chart { get; internal set; }
        /// <summary>
        /// The current <see cref="TimingWindows"/> being used for this <see cref="Gamemode"/>.
        /// </summary>
        public TimingWindows Windows { get; internal set; }
        /// <summary>
        /// The current <see cref="Mod"/>s being used for this <see cref="Gamemode"/>.
        /// </summary>
        public Mod[] Mods { get; internal set; }
        /// <summary>
        /// The current Name of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public string Name { get; internal set; } = "Unknown Song";
        /// <summary>
        /// The current Beats Per Minute of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public float Bpm { get; internal set; } = 180f;
        /// <summary>
        /// The current Speed of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public float Speed { get; internal set; } = 1f;
        /// <summary>
        /// The current Position of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public float Position { get; internal set; } = 0f;
        /// <summary>
        /// The current Beat of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public float Beat => Position * (Bpm / 60f);
        /// <summary>
        /// The Length of the song being used for this <see cref="Gamemode"/>.
        /// </summary>
        public float Length { get; internal set; } = 1f;
        /// <summary>
        /// The current Health of the player in this <see cref="Gamemode"/>.
        /// </summary>
        public float Health { get; internal set; } = 1f;

        /// <summary>
        /// Gets if the <see cref="Gamemode"/> is currently running.
        /// </summary>
        public bool Playing => playing;

        private Stopwatch deltaTimer;

        public T As<T>() where T : Gamemode
        {
            return (T)this;
        }

        private void ApplyMods()
        {
            foreach (Mod mod in Mods)
            {
                mod.Apply(this);
            }
        }

        internal void Setup(TimingWindows timings, Mod[] mods)
        {
            Windows = timings;
            Mods = mods;
            ApplyMods();

            Setup();
        }

        internal void Init()
        {
            Ready();

            while (playing)
            {
                Process();
            }
        }

        internal void Stop()
        {
            playing = false;
            deltaTimer.Stop();
        }

        public void Ready()
        {
            playing = true;

            Start();

            deltaTimer = new Stopwatch();
            deltaTimer.Start();
        }

        public void Process()
        {
            Position = (float)deltaTimer.Elapsed.TotalSeconds * Speed;

            Input.Update();
            Update();
        }

        internal abstract void Setup();
        internal abstract void Start();
        internal abstract void Update();

        /// <summary>
        /// Creates a new <see cref="Gamemode"/> instance.
        /// </summary>
        public Gamemode()
        {

        }

        /// <summary>
        /// Creates a new <see cref="Gamemode"/> instance with custom <see cref="TimingWindows"/>.
        /// </summary>
        public Gamemode(TimingWindows timings)
        {
            Windows = timings;
        }

        /// <summary>
        /// Creates a new <see cref="Gamemode"/> instance with custom <see cref="Mod"/>s.
        /// </summary>
        public Gamemode(params Mod[] mods)
        {
            Mods = mods;
            ApplyMods();
        }

        /// <summary>
        /// Creates a new <see cref="Gamemode"/> instance with custom <see cref="TimingWindows"/> and <see cref="Mod"/>s.
        /// </summary>
        public Gamemode(TimingWindows timings, params Mod[] mods)
        {
            Windows = timings;
            Mods = mods;
            ApplyMods();
        }
    }
}
