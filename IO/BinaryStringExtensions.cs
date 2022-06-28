using System;
using System.IO;
using System.Text;

namespace Rhein.IO
{
    internal static class BinaryStringExtensions
    {
        public static string ReadUtf8(this BinaryReader reader)
        {
            return ReadString(reader, Encoding.UTF8);
        }

        public static string ReadUnicode(this BinaryReader reader)
        {
            return ReadString(reader, Encoding.Unicode);
        }

        public static string ReadString(this BinaryReader reader, Encoding encoding)
        {
            return encoding.GetString(reader.ReadBytes(reader.ReadUInt16()));
        }

        public static void WriteUtf8(this BinaryWriter writer, string str)
        {
            WriteString(writer, Encoding.UTF8, str);
        }

        public static void WriteUnicode(this BinaryWriter writer, string str)
        {
            WriteString(writer, Encoding.Unicode, str);
        }

        public static void WriteString(this BinaryWriter writer, Encoding encoding, string str)
        {
            writer.Write((ushort)str.Length);
            writer.Write(encoding.GetBytes(str));
        }
    }
}
