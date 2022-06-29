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
using System.Collections.Generic;
using System.Text;

namespace Rhein.Rulesets.Scoring.Judgements
{
    /// <summary>An interface for judging hit timings.</summary>
    public interface IJudgement
    {
        /// <summary>The full display name of the judgement.</summary>
        public string Name { get; }
        /// <summary>The short label of the judgement for UI labels.</summary>
        public string Label { get; }
        /// <summary>The value which this judgement contributes to the accuracy.</summary>
        public float Weight { get; }
        /// <summary>The amount in milliseconds which the hit needs to occur in to get this judgement.</summary>
        public int Window { get; }

        /// <summary>Compares the weight of the two judgements to determine if a is less than b.</summary>
        public static bool operator <(IJudgement a, IJudgement b)
            => a.Weight < b.Weight;
        /// <summary>Compares the weight of the two judgements to determine if a is greater than b.</summary>
        public static bool operator >(IJudgement a, IJudgement b)
            => a.Weight > b.Weight;
        /// <summary>Compares the weight of the two judgements to determine if a is less than or equal to b.</summary>
        public static bool operator <=(IJudgement a, IJudgement b)
            => a.Weight <= b.Weight;
        /// <summary>Compares the weight of the two judgements to determine if a is greater than or equal to b.</summary>
        public static bool operator >=(IJudgement a, IJudgement b)
            => a.Weight >= b.Weight;
    }
}
