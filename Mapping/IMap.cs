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
