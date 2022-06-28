using System;
using System.IO;

using Rhein.Mapping;
using Rhein.Mods;
using Rhein.Rulesets;

namespace Rhein.IO
{
    /// <summary>The parser for a note.</summary>
    public class NoteParser<T> : Parser<T> where T : Note
    {
        /// <inheritdoc/>
        public override void Read(BinaryReader br, T obj)
        {
            obj.Time = br.ReadSingle();
            obj.Judged = false;
            obj.Judgement = null;
        }

        /// <inheritdoc/>
        public override void Write(BinaryWriter bw, T obj)
        {
            bw.Write(obj.Time);
        }
    }
}
