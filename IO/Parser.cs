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
using System.IO;

namespace Rhein.IO
{
    /// <summary>A base class for parsing objects from binary files.</summary>
    public abstract class Parser<T> where T : class
    {
        /// <summary>The 5-byte long header contained within a Rhein Engine file.</summary>
        public const long Header = 0x4E49454852;

        /// <summary>Gets an object from a file.</summary>
        public bool From(string file, ref T obj)
        {
            using FileStream fs = File.OpenRead(file);
            return From(fs, obj);
        }

        /// <summary>Gets an object from a stream.</summary>
        public bool From(Stream stream, T obj)
        {
            using BinaryReader br = new BinaryReader(stream);

            if (br.ReadInt64() != Header)
                return false;
            
            Read(br, obj);
            return true;
        }

        /// <summary>Writes an object to a file.</summary>
        public bool To(string file, T obj)
        {
            using FileStream fs = File.OpenWrite(file);
            return From(fs, obj);
        }

        /// <summary>Writes an object to a stream.</summary>
        public void To(Stream stream, T obj)
        {
            using BinaryWriter bw = new BinaryWriter(stream);

            bw.Write(Header);

            Write(bw, obj);
        }

        /// <summary>Initializes an object from a <see cref="BinaryReader"/>.</summary>
        public abstract void Read(BinaryReader br, T obj);
        /// <summary>Writes an object to a file with a <see cref="BinaryWriter"/>.</summary>
        public abstract void Write(BinaryWriter bw, T obj);
    }
}
