﻿/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using Rhein.Collections;

namespace Rhein.Gameplay
{
    /// <summary>
    /// The base class for all <see cref="Chart"/>s.
    /// </summary>
    public interface IChart
    {
        internal void AddNote(Note note);
        internal void AddEvent(Event ev);
    }
}