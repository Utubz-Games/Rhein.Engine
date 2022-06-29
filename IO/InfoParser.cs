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

using Rhein.Collections;
using Rhein.Mapping;
using Rhein.Mods;
using Rhein.Rulesets;

namespace Rhein.IO
{
    /// <summary>The parser for info.</summary>
    public class InfoParser : Parser<Info>
    {
        /// <inheritdoc/>
        public override void Read(BinaryReader br, Info obj)
        {
            for (int i = 0; i < br.ReadUInt16(); i++)
            {
                obj.SetProperty(br.ReadUtf8(), br.ReadUtf8());
            }
        }

        /// <inheritdoc/>
        public override void Write(BinaryWriter br, Info obj)
        {
            br.Write((ushort)obj.Count);
            foreach(string key in obj)
                br.WriteUtf8(obj[key]);
        }
    }
}
