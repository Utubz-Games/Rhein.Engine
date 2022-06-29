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
    public abstract class Health : IEquatable<Health>
    {
        /// <summary>The <see cref="Rulesets.Ruleset"/> which this scorer works for.</summary>
        public Ruleset Ruleset { get; }
        /// <summary>A value ranging from 0.0 to 1.0.</summary>
        public double Value { get; set; }

        /// <summary>Called once a note is judged.</summary>
        public abstract void OnJudge(Note note, IJudgement judgement);

        #region IEquatable

        /// <inheritdoc/>
        public bool Equals(Health x)
        {
            return x.GetType() == GetType();
        }

        /// <inheritdoc/>
        public sealed override bool Equals(object obj)
        {
            return obj is Health && Equals((Health)obj);
        }

        /// <inheritdoc/>
        public sealed override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public sealed override string ToString()
        {
            return (Value * 100.0).ToString();
        }

        /// <inheritdoc/>
        public static bool operator ==(Health a, Health b)
            => (object)a != null && (object)b != null && a.Equals(b);

        /// <inheritdoc/>
        public static bool operator !=(Health a, Health b)
            => !(a == b);

        #endregion

        /// <inheritdoc/>
        public Health(Ruleset rules)
            => Ruleset = rules;
    }
}
