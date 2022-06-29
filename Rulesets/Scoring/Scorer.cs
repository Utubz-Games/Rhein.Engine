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
using Rhein.Mapping;
using Rhein.Rulesets.Scoring.Judgements;

namespace Rhein.Rulesets.Scoring
{
    /// <summary>A base scorer class which scores gameplay.</summary>
    public abstract class Scorer : IEquatable<Scorer>
    {
        /// <summary>The <see cref="Rulesets.Ruleset"/> which this scorer works for.</summary>
        public Ruleset Ruleset { get; }
        /// <summary>The timer which provides timings windows for the scorer.</summary>
        public abstract Timer Timer { get; }
        /// <summary>The minimum judgement for a combo break.</summary>
        public abstract IJudgement Break { get; }
        /// <summary>The current combo of the map.</summary>
        public uint Combo { get; set; }
        /// <summary>The current score of the map.</summary>
        public uint Score { get; set; }

        /// <summary>Assigns a judgement to the note if applicable.</summary>
        public bool Judge(float time, ref Note note)
        {
            return Timer.TryJudge((int)((time - note.Time) * 1000f), ref note);
        }

        /// <summary>Breaks the combo by setting it to 0 and calling any necessary events.</summary>
        public void BreakCombo()
        {
            Combo = 0;
        }

        /// <summary>Called once a note is judged.</summary>
        public abstract void OnJudge(Note note, IJudgement judgement);

        #region IEquatable

        /// <inheritdoc/>
        public bool Equals(Scorer x)
        {
            return x.GetType() == GetType();
        }

        /// <inheritdoc/>
        public sealed override bool Equals(object obj)
        {
            return obj is Scorer && Equals((Scorer)obj);
        }

        /// <inheritdoc/>
        public sealed override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public sealed override string ToString()
        {
            return Combo.ToString("0000000");
        }

        /// <inheritdoc/>
        public static bool operator ==(Scorer a, Scorer b)
            => (object)a != null && (object)b != null && a.Equals(b);

        /// <inheritdoc/>
        public static bool operator !=(Scorer a, Scorer b)
            => !(a == b);

        #endregion

        /// <inheritdoc/>
        public Scorer(Ruleset rules)
            => Ruleset = rules;
    }
}
