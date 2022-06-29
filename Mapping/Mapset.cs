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
