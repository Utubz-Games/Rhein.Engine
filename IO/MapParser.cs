using System;
using System.IO;

using Rhein.Mapping;
using Rhein.Mods;
using Rhein.Rulesets;

namespace Rhein.IO
{
    /// <summary>The parser for a map.</summary>
    public class MapParser<T> : Parser<Map<T>> where T : Note
    {
        private InfoParser infoParser;
        private NoteParser<T> noteParser;

        /// <inheritdoc/>
        public override void Read(BinaryReader br, Map<T> map)
        {
            infoParser.Read(br, map.Info);
            ushort len = br.ReadUInt16();
            map.Notes.Capacity = len;
            T note;

            for (int i = 0; i < len; i++)
            {
                note = Activator.CreateInstance<T>();
                noteParser.Read(br, note);
                map.Notes.Add(note);
            }

            map.Bpm = br.ReadSingle();
        }


        /// <inheritdoc/>
        public override void Write(BinaryWriter bw, Map<T> map)
        {
            infoParser.Write(bw, map.Info);

            bw.Write((ushort)map.Notes.Count);
            for (int i = 0; i < map.Notes.Count; i++)
                noteParser.Write(bw, map.Notes[i]);

            bw.Write(map.Bpm);
        }

        /// <inheritdoc/>
        public MapParser(InfoParser ip, NoteParser<T> np)
        {
            infoParser = ip;
            noteParser = np;
        }
    }
}
