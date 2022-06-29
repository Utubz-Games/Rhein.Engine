#region License

/* 
 * Rhein.Engine - A .NET framework for rhythm games
 * Copyright (c) 2022 Jaiden "398utubzyt" Garcia
 * 
 * Licensed under the MIT license.
 * See the LICENSE file in the repository root for more details.
 */

#endregion

using System;
using System.Threading;

using Rhein.Mapping;
using Rhein.Mods;
using Rhein.Rulesets;

namespace Rhein
{
    /// <summary>A base game class for running a Rhein Engine loop.</summary>
    public abstract class Game
    {
        private bool __run = false;
        private Thread __thread;

        /// <summary>The current map being used by the game.</summary>
        public IMap Map { get; set; }
        /// <summary>The current ruleset being used by the game.</summary>
        public Ruleset Ruleset { get; set; }
        /// <summary>The current game thread.</summary>
        public Thread Thread => __thread;
        /// <summary>The game's current running status.</summary>
        public bool Running => __run;

        private void Main()
        {
            Begin();

            while (__run)
                Update();
        }

        /// <summary>Starts the game with the current map and ruleset.</summary>
        /// <param name="newThread">Decides whether to start a new thread and auto-update, or to start on the current thread and manually update.</param>
        /// <remarks>If the game is running on another thread, it will not start immediately as it needs to create the new thread and initialize data on it.</remarks>
        public void Start(bool newThread = true)
        {
            if (__run)
                return;

            if (Map == null || Ruleset == null)
                return;

            __run = true;

            if (newThread)
            {
                __thread = new Thread(Main);
                __thread.Name = "Rhein Thread";
                __thread.IsBackground = true;
                __thread.Priority = ThreadPriority.AboveNormal;
                __thread.Start();
            } else
            {
                __thread = Thread.CurrentThread;
                Begin();
            }
        }

        /// <summary>Stops the current game.</summary>
        /// <remarks>If the game is running on another thread, it will not stop immediately as it needs to finish the current loop to exit properly.</remarks>
        public void Stop()
        {
            if (!__run)
                return;

            __run = false;
        }

        /// <summary>Used for initialization before running the game.</summary>
        protected virtual void Begin() { }
        /// <summary>Used for denitialization after stopping the game.</summary>
        protected virtual void End() { }
        /// <summary>Updates the game.</summary>
        public abstract void Update();
    }
}
