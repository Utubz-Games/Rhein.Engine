/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Mods;
using Rhein.Gameplay;
using System.Diagnostics;

namespace Rhein.Gamemodes
{
    /// <summary>
    /// An abstract <see cref="Gamemode{T}"/> to implement your own gameplay styles.
    /// This class contains everything related to current gameplay.
    /// </summary>
    public abstract class Gamemode<T> : BaseGamemode where T : Note
    {
        private bool playing;
        private double offset;

        public override event UpdateHandler OnUpdate;
        public override event PreUpdateHandler OnPreUpdate;

        public override G As<G>() => (G)(BaseGamemode)this;

        /// <summary>
        /// The current <see cref="Chart{T}"/> being used for this <see cref="Gamemode"/>.
        /// </summary>
        public Chart<T> Chart { get; internal set; }
        public override Chart<N> GetChart<N>()
        {
            if (typeof(N) != typeof(T))
                return null;
            return (Chart<N>)(IChart)Chart;
        }

        public override TimingWindows Windows { get; internal set; }
        public override Mod[] Mods { get; internal set; }
        public override string Name { get; internal set; } = "Unknown Song";
        public override float Bpm { get; internal set; } = 120f;
        public override float Offset { get; internal set; } = 30f;
        public override float Speed { get; internal set; } = 1f;
        public override float Position { get; internal set; } = 0f;
        public override float Beat => Position * (Bpm / 60f);
        public override float Length { get; internal set; } = 1f;
        public override float Health { get; internal set; } = 1f;

        public bool Playing => playing;

        private Stopwatch deltaTimer;

        internal override void ApplyMods()
        {
            foreach (Mod mod in Mods)
            {
                mod.Apply(this);
            }
        }

        internal override void Setup(TimingWindows timings, Mod[] mods)
        {
            Windows = timings;
            Mods = mods;
            ApplyMods();

            Setup();

            Offset += Chart.Offset;
        }

        internal override void Init()
        {
            Ready();
            while (playing)
            {
                Process();
            }
        }

        internal override void Stop()
        {
            playing = false;
            deltaTimer.Stop();
        }

        internal override void Ready()
        {
            playing = true;

            Start();

            deltaTimer = new Stopwatch();
            deltaTimer.Start();
        }

        public override void Process()
        {
            Position = (float)(deltaTimer.Elapsed.TotalSeconds + offset) * Speed + Offset;

            OnPreUpdate?.Invoke();
            Update();
            OnUpdate?.Invoke();
        }

        internal abstract void Setup();
        internal abstract void Start();
        internal abstract void Update();

        public override void Sync(float position)
        {
            offset = position - deltaTimer.Elapsed.TotalSeconds - Offset;
        }

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
