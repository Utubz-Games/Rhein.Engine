/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Threading;

using Rhein.Gameplay;
using Rhein.Gamemodes;
using Rhein.Mods;

namespace Rhein
{
    /// <summary>
    /// The current Rhein Engine <see cref="Game"/>.
    /// </summary>
    public static class Game
    {
        private static Gamemode gamemode;
        private static bool started;
        /// <summary>
        /// Gets the current <see cref="Gamemodes.Gamemode"/> of the <see cref="Game"/>.
        /// </summary>
        public static Gamemode Gamemode => gamemode;

        /// <summary>
        /// Gets if the <see cref="Game"/> is currently running.
        /// </summary>
        public static bool Running => started;

        /// <summary>
        /// Starts a new <see cref="Mania4k"/> <see cref="Game"/> with <see cref="Rhein.TimingWindows.Default"/> and no <see cref="Mod"/>s.
        /// </summary>
        /// 
        /// <returns>The <see cref="Result"/> status of <see cref="Run()"/>.</returns>
        public static Result Run()
        {
            if (started)
                return Result.AlreadyStarted;

            started = true;

            gamemode = new Mania4k();
            gamemode.Setup(TimingWindows.Default, Array.Empty<Mod>());
            gamemode.Init();

            Logger.Write($"Started a Mania4k game.");

            return Result.Ok;
        }

        /// <summary>
        /// Starts a new <see cref="Mania4k"/> <see cref="Game"/> with the provided <see cref="Rhein.TimingWindows"/> and <see cref="Mod"/>s.
        /// </summary>
        /// 
        /// <returns>The <see cref="Result"/> status of <see cref="Run(TimingWindows, Mod[])"/>.</returns>
        public static Result Run(TimingWindows timings, params Mod[] mods)
        {
            if (started)
                return Result.AlreadyStarted;

            started = true;

            gamemode = new Mania4k();
            gamemode.Setup(timings, mods);
            gamemode.Init();

            Logger.Write($"Started a Mania4k game.");

            return Result.Ok;
        }

        /// <summary>
        /// Starts a new specified <see cref="Game"/> with the provided <see cref="Rhein.TimingWindows"/> and <see cref="Mod"/>s.
        /// </summary>
        /// 
        /// <returns>The <see cref="Result"/> status of <see cref="Run{T}(TimingWindows, Mod[])"/>.</returns>
        public static Result Run<T>(TimingWindows timings, params Mod[] mods) where T : Gamemode
        {
            if (started)
                return Result.AlreadyStarted;

            started = true;

            gamemode = Activator.CreateInstance<T>();
            gamemode.Setup(timings, mods);
            gamemode.Init();

            Logger.Write($"Started a {gamemode.GetType().Name} game.");

            return Result.Ok;
        }

        /// <summary>
        /// Stops the current <see cref="Game"/>.
        /// </summary>
        public static void Stop()
        {
            if (!started)
                return;

            Logger.Write($"Ending the {gamemode.GetType().Name} game.");
            gamemode.Stop();
            started = false;
        }

        /// <summary>
        /// Syncs the Rhein Engine music position with an external one.
        /// </summary>
        /// <param name="pos"></param>
        public static void Sync(float pos)
        {
            if (!started)
                return;

            gamemode.Position = pos;
        }

        /// <summary>
        /// The current <see cref="Gameplay.Chart"/> being used for this <see cref="Game"/>.
        /// </summary>
        public static Chart Chart => gamemode.Chart;
        /// <summary>
        /// The current <see cref="Rhein.TimingWindows"/> being used for this <see cref="Game"/>.
        /// </summary>
        public static TimingWindows TimingWindows => gamemode.Windows;
        /// <summary>
        /// The current <see cref="Mod"/>s being used for this <see cref="Game"/>.
        /// </summary>
        public static Mod[] Mods => gamemode.Mods;
        /// <summary>
        /// The current Name of the song being used for this <see cref="Game"/>.
        /// </summary>
        public static string Name => gamemode.Name;
        /// <summary>
        /// The current Beats Per Minute of the song being used for this <see cref="Game"/>.
        /// </summary>
        public static float Bpm => gamemode.Bpm;
        /// <summary>
        /// The current Health of the player in this <see cref="Game"/>.
        /// </summary>
        public static float Health => gamemode.Health;
        /// <summary>
        /// The current Speed of the song being used for this <see cref="Game"/>.
        /// </summary>
        public static float Speed => gamemode.Speed;
        /// <summary>
        /// The current Position of the song being used for this <see cref="Game"/>.
        /// </summary>
        public static float Position => gamemode.Position;
        /// <summary>
        /// The current Length of the song being used for this <see cref="Game"/>.
        /// </summary>
        public static float Length => gamemode.Length;
        /// <summary>
        /// The current Beat of the song being used for this <see cref="Game"/>.
        /// </summary>
        public static float Beat => gamemode.Beat;
    }
}
