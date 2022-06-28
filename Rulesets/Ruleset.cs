using System;

using Rhein.Rulesets.Scoring;
using Rhein.Rulesets.Scoring.Judgements;
using Rhein.Mods;
using Rhein.Mapping;

namespace Rhein.Rulesets
{
    /// <summary>A base ruleset class for implementing custom rules for gamemodes.</summary>
    public abstract class Ruleset : IEquatable<Ruleset>
    {
        /// <summary>The display name of the ruleset.</summary>
        public abstract string Name { get; }
        /// <summary>The <see cref="Scoring.Scorer"/> which provides scores for this ruleset.</summary>
        public abstract Scorer Scorer { get; }
        /// <summary>The <see cref="Scoring.Health"/> of the ruleset.</summary>
        public abstract Health Health { get; }
        /// <summary>The <see cref="Mod"/>s used by the ruleset.</summary>
        public ModList Mods { get; }

        /// <summary>Assigns a <see cref="IJudgement"/> to the note if applicable.</summary>
        public bool Judge(Note note, float time)
        {
            if (Scorer.Judge(note, time))
            {
                Scorer.OnJudge(note, note.Judgement);
                Health.OnJudge(note, note.Judgement);
                OnJudge(note, note.Judgement);
                return true;
            }

            return false;
        }

        /// <summary>Called once a note is judged.</summary>
        public abstract void OnJudge(Note note, IJudgement judgement);

        #region IEquatable

        /// <inheritdoc/>
        public bool Equals(Ruleset x)
        {
            return x.GetType() == GetType();
        }

        /// <inheritdoc/>
        public sealed override bool Equals(object obj)
        {
            return obj is Ruleset && Equals((Ruleset)obj);
        }

        /// <inheritdoc/>
        public sealed override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <inheritdoc/>
        public sealed override string ToString()
        {
            return Name;
        }

        /// <inheritdoc/>
        public static bool operator ==(Ruleset a, Ruleset b)
            => (object)a != null && (object)b != null && a.Equals(b);

        /// <inheritdoc/>
        public static bool operator !=(Ruleset a, Ruleset b)
            => !(a == b);

        #endregion
    }
}
