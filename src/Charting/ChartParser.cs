/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  (C) 2021 Jaiden "398utubzyt" Garcia
 */

using StringBuilder = System.Text.StringBuilder;
using System.IO;

using Rhein;
using Rhein.Gameplay;

namespace Rhein.Charting
{
    /// <summary>
    /// Used to parse <see cref="Chart"/>s.
    /// </summary>
    public static class ChartParser
    {
        /// <summary>
        /// The header at the top of a Rhein Engine chart file (.rch);
        /// </summary>
        public const string Header = "RHEIN CHART";
        /// <summary>
        /// The prefix right before the version number in a Rhein Engine chart file (.rch);
        /// </summary>
        public const string VersionPrefix = "VERSION ";
        /// <summary>
        /// The current version of the Rhein Engine chart format.
        /// </summary>
        public const int Version = 1;

        /// <summary>
        /// Converts the <see cref="Chart"/> to a <see cref="string"/> that can be saved to a file.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Chart"/> to parse.</typeparam>
        /// <param name="chart">The <see cref="Chart"/> to parse.</param>
        /// <returns>A <see cref="Chart"/> in string form.</returns>
        public static string ToString<T>(T chart) where T : Chart
        {
            StringBuilder builder = new StringBuilder();

            return builder.ToString();
        }

        /// <summary>
        /// Converts the <see cref="string"/> to a <see cref="Chart"/> that can be used at run-time.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Chart"/> to convert to.</typeparam>
        /// <param name="str">The <see cref="string"/> to parse.</param>
        /// <returns>A <see cref="Chart"/> in run-time form.</returns>
        public static T ToChart<T>(string str) where T : Chart, new()
        {
            using StringReader reader = new StringReader(str);

            // Check header to make sure it's a valid file.
            if (reader.ReadLine() != Header)
                return null;

            string verString = reader.ReadLine();

            // Check version prefix before checking version.
            if (verString.Substring(0, VersionPrefix.Length) != VersionPrefix)
                return null;

            // Check if version number is a valid number.
            if (!int.TryParse(verString.Substring(VersionPrefix.Length - 1), out int version))
                return null;

            reader.ReadLine();

            T chart = new T();

            chart.Notes = new Collections.GenericNoteCollection();
            chart.Events = new Collections.GenericEventCollection();

            switch (version)
            {
                case 1:
                    ToChartV1(reader, chart);
                    break;

                default:
                    ToChartV1(reader, chart);
                    break;
            }

            return chart;
        }

        private static void ToChartV1<T>(StringReader reader, T chart) where T : Chart
        {
            // 0 - None
            // 1 - Properties
            // 2 - Notes
            // 3 - Events
            int section = 0;
            int check;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                check = 0;

                switch (section)
                {
                    // Properties
                    case 1:
                        // Not a valid property if it isn't long enough. This is to prevent an out of bounds exception.
                        if (line.Length < 3 || !line.Contains(":"))
                            break;

                        string[] property = line.Replace(" ", "").Split(':');

                        switch (property[0])
                        {
                            case "Type":
                                if (int.TryParse(property[1], out int type))
                                    chart.Type = type;
                                break;

                            case "Bpm":
                                if (float.TryParse(property[1], out float bpm))
                                    chart.Bpm = bpm;
                                break;

                            case "Offset":
                                if (int.TryParse(property[1], out int offset))
                                    chart.Offset = offset;
                                break;
                        }
                        break;

                    // Notes
                    case 2:
                        // Not a valid property if it isn't long enough. This is to prevent an out of bounds exception.
                        if (line.Length < 5 || !line.Contains(":"))
                            break;

                        string[] noteProperty = line.Replace(" ", "").Split(':');
                        Note note = new ChartNote();
                        note.Length = 0f;
                        note.Hit = false;

                        if (int.TryParse(noteProperty[0], out int noteType))
                        {
                            note.Type = noteType;
                            check++;
                        }

                        if (float.TryParse(noteProperty[1], out float noteBeat))
                        {
                            note.Beat = noteBeat;
                            check++;
                        }

                        if (float.TryParse(noteProperty[2], out float noteLength))
                            note.Length = noteLength;

                        if (check >= 2)
                            chart.Notes.TryAdd(note);
                        break;

                    // Events
                    case 3:
                        // Not a valid property if it isn't long enough. This is to prevent an out of bounds exception.
                        if (line.Length < 5 || !line.Contains(":"))
                            break;

                        string[] eventProperty = line.Replace(" ", "").Split(':');
                        Event ev = new ChartEvent();
                        ev.Executed = false;

                        if (int.TryParse(eventProperty[0], out int eventType))
                        {
                            ev.Type = eventType;
                            check++;
                        }

                        if (float.TryParse(eventProperty[1], out float eventBeat))
                        {
                            ev.Beat = eventBeat;
                            check++;
                        }

                        ev.Value = eventProperty[2];

                        if (check >= 2)
                            chart.Events.Add(ev);
                        break;

                    // No Section
                    default:
                        if (line.StartsWith("[") && line.EndsWith("]"))
                        {
                            line = line.Remove(line.Length - 1).Substring(1);

                            switch (line)
                            {
                                case "Properties":
                                    section = 1;
                                    break;

                                case "Notes":
                                    section = 2;
                                    break;

                                case "Events":
                                    section = 3;
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
}
