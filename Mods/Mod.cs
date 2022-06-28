using System;
using System.Collections.Generic;
using System.Text;

using Rhein.Rulesets;
using Rhein.Mapping;

namespace Rhein.Mods
{
    /// <summary>A modification to the normal gameplay experience.</summary>
    public abstract class Mod : IEquatable<Mod>
    {
        /// <summary>The full display name of the mod.</summary>
        public abstract string Name { get; }
        /// <summary>The short label of the mod for UI labels.</summary>
        public abstract string Label { get; }
        /// <summary>The multiplier to multiply the score by.</summary>
        public abstract float Multiplier { get; }
        /// <summary>Decides whether the score from the game using this mod should be considered ranked.</summary>
        public virtual bool Ranked => false;

        /// <summary>Applies the mod.</summary>
        public abstract void Apply(Ruleset ruleset, IMap map);

        #region IEquatable

        /// <inheritdoc/>
        public bool Equals(Mod x)
        {
            return x.GetType() == GetType();
        }

        /// <inheritdoc/>
        public sealed override bool Equals(object obj)
        {
            return obj is Mod && Equals((Mod)obj);
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
        public static bool operator ==(Mod a, Mod b)
            => (object)a != null && (object)b != null && a.Equals(b);

        /// <inheritdoc/>
        public static bool operator !=(Mod a, Mod b)
            => !(a == b);

        #endregion
    }
}
