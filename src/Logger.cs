/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System.Diagnostics;

namespace Rhein
{
    /// <summary>
	/// The class that can hook into external functions to act as logging.
	/// </summary>
    public static class Logger
    {
        /// <summary>
        /// Handles logging.
        /// </summary>
        /// <param name="msg">The message to write.</param>
        /// <param name="type">The type of the message.</param>
        public delegate void LogHandle(string msg, int type);
        private static LogHandle handle;

        /// <summary>
        /// Used to handle logging with external libraries (usually the main engine).
        /// </summary>
        public static event LogHandle OnLog { add { handle += value; } remove { handle -= value; } }

        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="msg">The message to write.</param>
        public static void Write(string msg)
        {
            if (handle != null)
                handle(msg, 0);
            else
                SystemDebugWrite(msg, 0);
        }

        /// <summary>
        /// Writes a warning message to the log.
        /// </summary>
        /// <param name="msg">The message to write.</param>
        public static void WriteWarn(string msg)
        {
            if (handle != null)
                handle(msg, 1);
            else
                SystemDebugWrite(msg, 1);
        }

        /// <summary>
        /// Writes an error message to the log.
        /// </summary>
        /// <param name="msg">The message to write.</param>
        public static void WriteError(string msg)
        {
            if (handle != null)
                handle(msg, 2);
            else
                SystemDebugWrite(msg, 2);
        }

        /// <summary>
        /// Writes a message to the log without a prefix.
        /// </summary>
        /// <param name="msg">The message to write.</param>
        public static void WriteMsg(string msg)
        {
            if (handle != null)
                handle(msg, 0);
            else
                Debug.WriteLine(msg);
        }

        private static void SystemDebugWrite(string msg, int type)
        {
            Debug.WriteLine("{1}: {0}", msg, GetCode(type));
        }

        private static string GetCode(int type)
        {
            return type switch
            {
                0 => "LOG",
                1 => "WRN",
                2 => "ERR",
                _ => "LOG",
            };
        }
    }
}
