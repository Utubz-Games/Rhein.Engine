#region License

/* 
 * Rhein.Engine - A .NET framework for rhythm games
 * Copyright (c) 2022 Jaiden "398utubzyt" Garcia
 * 
 * Licensed under the MIT license.
 * See the LICENSE file in the repository root for more details.
 */

#endregion

using Rhein.Collections;

namespace Rhein.Mapping
{
    /// <summary>A map which holds notes for the player to hit during gameplay.</summary>
    public class Map<T> : IMap where T : Note
    {
        /// <inheritdoc/>
        public Map<N> As<N>() where N : Note
            => (Map<N>)(IMap)this;

        /// <inheritdoc/>
        public Mapset Mapset { get; set; }
        /// <inheritdoc/>
        public MapInfo Info { get; set; } = new MapInfo();
        /// <summary>The notes of the map.</summary>
        public List<T> Notes { get; set; } = new List<T>();
        /// <inheritdoc/>
        public float Bpm { get; set; } = 120f;

        /// <inheritdoc/>
        public virtual object Clone()
        {
            Map<T> map = new Map<T>()
            {
                Mapset = Mapset,
                Info = (MapInfo)Info.Clone(),
                Notes = (List<T>)Notes.Clone(),
                Bpm = Bpm
            };

            return map;
        }
    }
}
