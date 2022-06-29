#region License

/* 
 * Rhein.Engine - A .NET framework for rhythm games
 * Copyright (c) 2022 Jaiden "398utubzyt" Garcia
 * 
 * Licensed under the MIT license.
 * See the LICENSE file in the repository root for more details.
 */

#endregion

using Rhein.Rulesets;
using Rhein.Mapping;
using Rhein.Collections;

namespace Rhein.Mods
{
    /// <summary>A list of mods.</summary>
    public class ModList : List<Mod>
    {
        /// <summary>Applies the mods in the list.</summary>
        public void Apply(Ruleset ruleset, IMap map)
        {
            for (int i = 0; i < Count; i++)
                this[i].Apply(ruleset, map);
        }
    }
}
