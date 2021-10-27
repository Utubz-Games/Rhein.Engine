/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections;
using Rhein.Gameplay;
using Rhein.Gameplay.Mania;

namespace Rhein.Gamemodes
{
    /// <summary>
    /// An abstract <see cref="Mania"/> <see cref="Gamemode"/> class to be implemented by your own <see cref="Mania"/> gamemodes.
    /// </summary>
    public abstract class Mania : Gamemode
    {
        private static readonly Key[] keys = { Key.D, Key.F, Key.J, Key.K };

        /// <summary>
        /// The amount of keys used in the current <see cref="Mania"/> <see cref="Gamemode"/>.
        /// </summary>
        public abstract int Keys { get; }
        /// <summary>
        /// The collection of <see cref="Lane"/>s in the current <see cref="Mania"/> <see cref="Gamemode"/>.
        /// </summary>
        public LaneCollection Lanes { get; internal set; }

        internal override void Setup()
        {
            Lanes = new LaneCollection(Keys);
            Chart = new ManiaChart();
            Chart.Notes = new GenericNoteCollection();

            
        }

        internal override void Start()
        {
            
        }

        internal override void Update()
        {
            for (int i = 0; i < Keys; i++)
            {
                if (Lanes[i].Notes.TryHasNext())
                {
                    if (!Lanes[i].Notes.TryNotNull())
                    {
                        Logger.Write("Internal Note is null??");
                        Lanes[i].Notes.TryRemove();
                        return;
                    } else if (Lanes[i].Notes.TryPeek(out ManiaNote note))
                    {
                        note.Deviance = Position - (note.Beat / (Bpm / 60f));

                        if (note.Deviance > Windows.Miss)
                        {
                            note.Destroyed = true;
                            note.Deviance = (Windows.Miss + 1f) * 0.001f;
                            Lanes[i].Notes.TryRemove();
                        } else if (Input.KeyDown(keys[i]))
                        {
                            //Logger.Write($"key was pressed: {Math.Abs(note.Deviance * 1000f)} - {Windows.Miss}");
                            if (Math.Abs(note.Deviance * 100f) <= Windows.Miss)
                            {
                                note.Hit = true;
                                note.Destroyed = true;
                                Lanes[i].Notes.TryRemove();
                                Logger.Write("Internal Note was hit");
                            }
                        }
                    }
                }
            }
        }
    }
}
