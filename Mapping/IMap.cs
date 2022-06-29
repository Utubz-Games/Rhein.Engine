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
    /// <summary>A map interface used for holding a map instance without knowing the note type.</summary>
    public interface IMap : ICloneable
    {
        /// <summary>The set which this map belongs to.</summary>
        public Mapset Mapset { get; set; }
        /// <summary>Info relating to the map.</summary>
        public MapInfo Info { get; set; }
        /// <summary>The tempo of the map.</summary>
        public float Bpm { get; set; }

        /// <summary>Casts the interface to the proper type.</summary>
        public Map<T> As<T>() where T : Note;
    }
}
