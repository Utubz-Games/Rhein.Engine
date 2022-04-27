/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

namespace Rhein
{
    /// <summary>
    /// <see cref="Judgement"/> <see cref="TimingWindows"/> for a <see cref="Gamemodes.Gamemode"/>.
    /// </summary>
    public readonly struct TimingWindows
    {
        /// <summary>The <see cref="Judgement.Marvelous"/> window.</summary>
        public readonly int Marvelous;
        /// <summary>The <see cref="Judgement.Perfect"/> window.</summary>
        public readonly int Perfect;
        /// <summary>The <see cref="Judgement.Great"/> window.</summary>
        public readonly int Great;
        /// <summary>The <see cref="Judgement.Good"/> window.</summary>
        public readonly int Good;
        /// <summary>The <see cref="Judgement.Okay"/> window.</summary>
        public readonly int Okay;
        /// <summary>The <see cref="Judgement.Miss"/> window.</summary>
        public readonly int Miss;
        /// <summary>Gets if the <see cref="TimingWindows"/> are the same as the <see cref="Default"/> windows.</summary>
        public readonly bool IsDefault;

        public bool TooLate(float sec)
            => sec * 1000f > Miss;

        public bool TooLate(int ms)
            => ms > Miss;

        public bool Hittable(float sec)
            => Math.Abs(sec * 1000f) <= Miss;

        public bool Hittable(int ms)
            => Math.Abs(ms) <= Miss;

        public Judgement Get(float sec)
        {
            sec = Math.Abs(sec * 1000f);
            if (sec <= Marvelous)
                return Judgement.Marvelous;
            else if (sec <= Perfect)
                return Judgement.Perfect;
            else if (sec <= Great)
                return Judgement.Great;
            else if (sec <= Good)
                return Judgement.Good;
            else if (sec <= Okay)
                return Judgement.Okay;
            else
                return Judgement.Miss;
        }

        public Judgement Get(int ms)
        {
            ms = Math.Abs(ms);
            if (ms <= Marvelous)
                return Judgement.Marvelous;
            else if (ms <= Perfect)
                return Judgement.Perfect;
            else if (ms <= Great)
                return Judgement.Great;
            else if (ms <= Good)
                return Judgement.Good;
            else if (ms <= Okay)
                return Judgement.Okay;
            else
                return Judgement.Miss;
        }

        /// <summary>The default <see cref="Judgement.Marvelous"/> window.</summary>
        public const int DefaultMarv  =  21;
        /// <summary>The default <see cref="Judgement.Perfect"/> window.</summary>
        public const int DefaultPerf  =  42;
        /// <summary>The default <see cref="Judgement.Great"/> window.</summary>
        public const int DefaultGreat =  83;
        /// <summary>The default <see cref="Judgement.Good"/> window.</summary>
        public const int DefaultGood  = 104;
        /// <summary>The default <see cref="Judgement.Okay"/> window.</summary>
        public const int DefaultOkay  = 125;
        /// <summary>The default <see cref="Judgement.Miss"/> window.</summary>
        public const int DefaultMiss  = 166;

        /// <summary>
        /// The default <see cref="TimingWindows"/> used in <see cref="Rhein"/> Engine.
        /// </summary>
        public static readonly TimingWindows Default = new TimingWindows(DefaultMarv, DefaultPerf, DefaultGreat, DefaultGood, DefaultOkay, DefaultMiss);

        /// <summary>
        /// The chill <see cref="TimingWindows"/> used in the <see cref="Mods.ChillTimingMod"/>.
        /// </summary>
        public static readonly TimingWindows Chill   = new TimingWindows(DefaultMarv + 1, DefaultPerf + 2, DefaultGreat + 3, DefaultGood + 4, DefaultOkay + 5,  DefaultMiss + 6);
        /// <summary>
        /// The lenient <see cref="TimingWindows"/> used in the <see cref="Mods.LenientTimingMod"/>.
        /// </summary>
        public static readonly TimingWindows Lenient = new TimingWindows(DefaultMarv + 2, DefaultPerf + 4, DefaultGreat + 6, DefaultGood + 8, DefaultOkay + 10, DefaultMiss + 12);

        /// <summary>
        /// The tight <see cref="TimingWindows"/> used in the <see cref="Mods.TightTimingMod"/>.
        /// </summary>
        public static readonly TimingWindows Tight  = new TimingWindows(DefaultMarv - 1, DefaultPerf - 2, DefaultGreat - 3, DefaultGood - 4, DefaultOkay - 5,  DefaultMiss - 6);
        /// <summary>
        /// The strict <see cref="TimingWindows"/> used in the <see cref="Mods.StrictTimingMod"/>.
        /// </summary>
        public static readonly TimingWindows Strict  = new TimingWindows(DefaultMarv - 2, DefaultPerf - 4, DefaultGreat - 6, DefaultGood - 8, DefaultOkay - 10, DefaultMiss - 12);

        /// <summary>
        /// Creates a <see cref="TimingWindows"/> with the specified <see cref="Judgement"/> windows.
        /// </summary>
        /// <param name="marv">The <see cref="Judgement.Marvelous"/> window.</param>
        /// <param name="perf">The <see cref="Judgement.Perfect"/> window.</param>
        /// <param name="great">The <see cref="Judgement.Great"/> window.</param>
        /// <param name="good">The <see cref="Judgement.Good"/> window.</param>
        /// <param name="okay">The <see cref="Judgement.Okay"/> window.</param>
        /// <param name="miss">The <see cref="Judgement.Miss"/> window.</param>
        public TimingWindows(int marv, int perf, int great, int good, int okay, int miss)
        {
            Marvelous = marv;
            Perfect = perf;
            Great = great;
            Good = good;
            Okay = okay;
            Miss = miss;

            IsDefault = marv == DefaultMarv && perf == DefaultPerf && great == DefaultGreat && good == DefaultGood && okay == DefaultOkay && miss == DefaultMiss;
        }
    }
}
