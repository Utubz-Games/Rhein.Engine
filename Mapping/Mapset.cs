using System;

using Rhein.Rulesets;

namespace Rhein.Mapping
{
    /// <summary>A map which holds notes for the player to hit during gameplay.</summary>
    public class Mapset : ICloneable
    {
        /// <inheritdoc/>
        public object Clone()
        {
            return new Mapset();
        }
    }
}
