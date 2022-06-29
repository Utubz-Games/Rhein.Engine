#region License

/* 
 * Rhein.Engine - A .NET framework for rhythm games
 * Copyright (c) 2022 Jaiden "398utubzyt" Garcia
 * 
 * Licensed under the MIT license.
 * See the LICENSE file in the repository root for more details.
 */

#endregion

using Rhein.Mapping;
using Rhein.Rulesets.Scoring.Judgements;

using System;
using System.Collections.Generic;
using System.Text;

namespace Rhein.Rulesets.Scoring
{
    /// <summary>A base class for defining timing windows for <see cref="IJudgement"/>s.</summary>
    public abstract class Timer
    {
        private class JudgementComparer : IComparer<IJudgement>
        {
            public int Compare(IJudgement x, IJudgement y)
            {
                return y.Window - x.Window;
            }
        }

        private readonly JudgementComparer Comparer = new JudgementComparer();

        /// <summary>Called when the <see cref="Judgements"/> array needs to be created. This is only called once per instance.</summary>
        protected abstract IJudgement[] InitializeJudgements();

        /// <summary>The list of judgements to be used ordered from smallest to largest timing window.</summary>
        public IJudgement[] Judgements { get; }

        /// <summary>Decides whether, given the provided <paramref name="time"/>, a judgement should be given.</summary>
        public bool Judgeable(int time)
        {
            return Judgements[^1].Window <= time;
        }

        /// <summary>Gives a <see cref="IJudgement"/> based on the provided <paramref name="time"/>.</summary>
        public IJudgement Judge(int time)
        {
            for (int i = 0; i < Judgements.Length; i++)
            {
                if (Judgements[i].Window <= time)
                    return Judgements[i];
            }

            return null;
        }

        /// <summary>Attempts to judge the note if it is within the right timing window. If not, then the note remains untouched.</summary>
        public bool TryJudge(int time, ref Note note)
        {
            if (Judgeable(time))
            {
                note.Judgement = Judge(time);
                return true;
            }
            return false;
        }

        /// <summary>The empty constructor for the timer.</summary>
        public Timer()
        {
            IJudgement[] arr = InitializeJudgements();
            Array.Sort(arr, Comparer);
            Judgements = arr;
        }
    }
}
