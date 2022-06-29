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
using System.Collections;
using System.Collections.Generic;

namespace Rhein.Collections
{
    /// <summary>A base class which contains info about a subject. This can be inherited to add default properties.</summary>
    public class Info : IEnumerable<string>, ICloneable
    {
        private Dictionary<string, string> dict;


        /// <summary>The number of properties within the info.</summary>
        public int Count => dict.Keys.Count;

        /// <summary>Gets if the info contains the provided <paramref name="key"/>.</summary>
        public bool HasProperty(string key)
            => dict.ContainsKey(key);

        /// <summary>Gets a property with the provided <paramref name="key"/>.</summary>
        public string GetProperty(string key)
            => dict[key];

        /// <summary>Adds a property with the provided <paramref name="key"/>.</summary>
        public void AddProperty(string key, string value)
            => dict.Add(key, value);

        /// <summary>Adds a property with the provided <paramref name="key"/>.</summary>
        public void RemoveProperty(string key)
            => dict.Remove(key);

        /// <summary>Sets a property with the provided <paramref name="key"/>.</summary>
        public void SetProperty(string key, string value)
        {
            if (HasProperty(key))
                dict[key] = value;
            else
                AddProperty(key, value);
        }

        /// <summary>Gets or sets a property with the provided <paramref name="key"/>.</summary>
        public string this[string key] { get => GetProperty(key); set => SetProperty(key, value); }

        #region IEnumerable

        /// <inheritdoc/>
        public IEnumerator<string> GetEnumerator()
        {
            return dict.Keys.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return dict.Keys.GetEnumerator();
        }

        #endregion

        #region ICloneable

        /// <inheritdoc/>
        public object Clone()
        {
            Info info = new Info();
            info.dict.Clear();

            foreach (string key in dict.Keys)
                info.SetProperty(key, dict[key]);

            return info;
        }

        #endregion

        /// <summary>Populates the current info with default properties.</summary>
        protected virtual void Populate() { }

        /// <summary>Creates an info object.</summary>
        public Info()
        {
            dict = new Dictionary<string, string>();
            Populate();
        }
    }
}
