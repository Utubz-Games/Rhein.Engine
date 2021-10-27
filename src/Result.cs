/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

namespace Rhein
{
    /// <summary>
    /// The status code <see cref="Result"/> returned by a <see cref="Rhein"/> Engine function.
    /// </summary>
    public readonly struct Result
    {
        /// <summary>
        /// The code of the <see cref="Result"/>.
        /// </summary>
        public readonly int value;
        /// <summary>
        /// Gets if the <see cref="Result"/> is equal to <see cref="Ok"/>.
        /// </summary>
        public readonly bool ok;

        /// <summary>
        /// Converts the <see cref="Result"/> to an <see cref="int"/> code.
        /// </summary>
        /// <param name="res">The <see cref="Result"/>.</param>
        public static implicit operator int(Result res) => res.value;
        /// <summary>
        /// Converts the <see cref="Result"/> to a <see cref="bool"/> ok value.
        /// </summary>
        /// <param name="res">The <see cref="Result"/>.</param>
        public static implicit operator bool(Result res) => res.value == 0;
        /// <summary>
        /// Converts the <see cref="int"/> code to a <see cref="Result"/>.
        /// </summary>
        /// <param name="code">The <see cref="int"/> code.</param>
        public static implicit operator Result(int code) => new Result(code);
        /// <summary>
        /// Converts the <see cref="bool"/> ok value to a <see cref="Result"/>.
        /// </summary>
        /// <param name="ok">The <see cref="bool"/> ok value.</param>
        public static implicit operator Result (bool ok) => new Result(ok ? 0 : -1);

        /// <summary>
        /// Creates a <see cref="Result"/> from the <see cref="int"/> code.
        /// </summary>
        /// <param name="code">The <see cref="int"/> code.</param>
        public Result(int code)
        {
            value = code;
            ok = code == 0;
        }

        /// <summary>Unknown <see cref="Result"/>.</summary>
        public static readonly Result Unknown = -1;
        /// <summary>Ok <see cref="Result"/>.</summary>
        public static readonly Result Ok = 0;
        /// <summary>Low Memory <see cref="Result"/>.</summary>
        public static readonly Result LowMemory = 1;
        /// <summary>Already Started <see cref="Result"/>.</summary>
        public static readonly Result AlreadyStarted = 2;
        /// <summary>Invalid Gamemode <see cref="Result"/>.</summary>
        public static readonly Result InvalidGamemode = 3;

        /// <summary>Unity: Using Old Input Module <see cref="Result"/>.</summary>
        public static readonly Result Unity_OldInputSystem = 1024;
    }
}
