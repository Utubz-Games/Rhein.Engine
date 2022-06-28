
using System;
using System.Collections;
using System.Collections.Generic;

namespace Rhein.Mapping
{
    /// <summary>Contains info specific to a map.</summary>
    public class MapInfo : Info
    {
        private const string PROP_TITLE = "Name";
        private const string PROP_AUTHOR = "Author";
        private const string PROP_ARTIST = "Artist";
        private const string PROP_DIFFICULTY = "Difficulty";

        private const string UNKNOWN_PROPERTY = "Unknown";
        private const string UNKNOWN_DIFFICULTY = "Easy";


        /// <summary>The title of the song.</summary>
        public string Title { get => GetProperty(PROP_TITLE); set => SetProperty(PROP_TITLE, value); }
        /// <summary>The author(s) of the map.</summary>
        public string Author { get => GetProperty(PROP_AUTHOR); set => SetProperty(PROP_AUTHOR, value); }
        /// <summary>The artist(s) of the song.</summary>
        public string Artist { get => GetProperty(PROP_ARTIST); set => SetProperty(PROP_ARTIST, value); }
        /// <summary>The display name for the difficulty of the map.</summary>
        public string Difficulty { get => GetProperty(PROP_DIFFICULTY); set => SetProperty(PROP_DIFFICULTY, value); }

        /// <inheritdoc/>
        protected override void Populate()
        {
            SetProperty(PROP_TITLE, UNKNOWN_PROPERTY);
            SetProperty(PROP_ARTIST, UNKNOWN_PROPERTY);
            SetProperty(PROP_AUTHOR, UNKNOWN_PROPERTY);
            SetProperty(PROP_DIFFICULTY, UNKNOWN_DIFFICULTY);
        }

    }
}
