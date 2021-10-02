using System;
using System.Threading;

using Rhein.Gamemodes;
using Rhein.Mods;

namespace Rhein
{
    public static class Game
    {
        private static Thread thread;
        private static Gamemode gamemode;

        /// <summary>
        /// Starts a new <see cref="Mania4k"/> game with no <see cref="Mod"/>s and default <see cref="TimingWindows"/>.
        /// </summary>
        /// <returns>The <see cref="Result"/> status of <see cref="Run"/></returns>
        public static Result Run()
        {
            return Run(TimingWindows.Default, Array.Empty<Mod>());
        }

        /// <summary>
        /// Starts a new <see cref="Mania4k"/> game with the provided <see cref="TimingWindows"/> and <see cref="Mod"/>s.
        /// </summary>
        /// 
        /// <returns>The <see cref="Result"/> status of <see cref="Run"/></returns>
        public static Result Run(TimingWindows timings, params Mod[] mods)
        {
            gamemode = new Mania4k(timings, mods);
            thread = new Thread(gamemode.Init);
            thread.Start();

            return Result.Ok;
        }

        /// <summary>
        /// Starts a new specified game with the provided <see cref="TimingWindows"/> and <see cref="Mod"/>s.
        /// </summary>
        /// 
        /// <returns>The <see cref="Result"/> status of <see cref="Run"/></returns>
        public static Result Run<T>(TimingWindows timings, params Mod[] mods) where T : Gamemode
        {
            gamemode = (Gamemode)Activator.CreateInstance(typeof(T), timings, mods);
            thread = new Thread(gamemode.Init);
            thread.Start();

            return Result.Ok;
        }
    }
}
