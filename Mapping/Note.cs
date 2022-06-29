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

using Rhein.Rulesets.Scoring.Judgements;

namespace Rhein.Mapping
{
    /// <summary>A base note class for implementing custom data.</summary>
    public abstract class Note : ICloneable
    {
        /// <summary>The time in beats at which the note should be hit.</summary>
        public float Time { get; set; }
        /// <summary>The note's judged state.</summary>
        public bool Judged { get; set; }
        /// <summary>The note's recieved judgement.</summary>
        public IJudgement Judgement { get; set; }

        /// <inheritdoc/>
        public object Clone()
        {
            return CloneNote();
        }

        /// <summary>Clones the note.</summary>
        protected abstract Note CloneNote();
    }
}
