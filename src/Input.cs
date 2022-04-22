/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Runtime.InteropServices;

namespace Rhein
{
	#region Enums
	/// <summary>
	/// The <see cref="Key"/> code of a <see cref="Key"/>.
	/// </summary>
	public enum Key
	{
		Ext = 0xE000,
		None = 0,

		Escape = 0x01,

		Alpha1 = 0x02,
		Alpha2 = 0x03,
		Alpha3 = 0x04,
		Alpha4 = 0x05,
		Alpha5 = 0x06,
		Alpha6 = 0x07,
		Alpha7 = 0x08,
		Alpha8 = 0x09,
		Alpha9 = 0x0A,
		Alpha0 = 0x0B,

		Minus = 0x0C,
		Plus = 0x0D,

		Backspace = 0x0E,
		Tab = 0x0F,

		Q = 0x10,
		W = 0x11,
		E = 0x12,
		R = 0x13,
		T = 0x14,
		Y = 0x15,
		U = 0x16,
		I = 0x17,
		O = 0x18,
		P = 0x19,
		A = 0x1E,
		S = 0x1F,
		D = 0x20,
		F = 0x21,
		G = 0x22,
		H = 0x23,
		J = 0x24,
		K = 0x25,
		L = 0x26,
		Z = 0x2C,
		X = 0x2D,
		C = 0x2E,
		V = 0x2F,
		B = 0x30,
		N = 0x31,
		M = 0x32,

		LeftBracket = 0x1A,
		RightBracket = 0x1B,
		Enter = 0x1C,

		LeftControl = 0x1D,
		RightControl = Ext + 0x1D,


		Semicolon = 0x27,
		Apostrophe = 0x28,
		Grave = 0x29,

		LeftShift = 0x2A,
		RightShift = 0x36,
		LeftAlt = 0x38,
		RightAlt = Ext + 0x38,

		Backslash = 0x2B,


		Comma = 0x33,
		Period = 0x34,
		Slash = 0x35,

		Space = 0x39,

		Capslock = 0x3A,

		F1 = 0x3B,
		F2 = 0x3C,
		F3 = 0x3D,
		F4 = 0x3E,
		F5 = 0x3F,
		F6 = 0x40,
		F7 = 0x41,
		F8 = 0x42,
		F9 = 0x43,
		F10 = 0x44,
		F11 = 0x57,
		F12 = 0x58,

		NumLock = 0x45,
		ScrollLock = 0x46,

		PadAdd = 0x4E,
		PadSubtract = 0x4A,
		PadMultiply = 0x37,
		PadDivide = Ext + 0x35,
		PadDecimal = 0x53,
		PadEnter = Ext + 0x35,

		Pad1 = 0x4F,
		Pad2 = 0x50,
		Pad3 = 0x51,
		Pad4 = 0x4B,
		Pad5 = 0x4C,
		Pad6 = 0x4D,
		Pad7 = 0x47,
		Pad8 = 0x48,
		Pad9 = 0x49,
		Pad0 = 0x52,

		Up = Ext + 0x48,
		Left = Ext + 0x4B,
		Right = Ext + 0x4D,
		Down = Ext + 0x50,

		PrintScreen = 0x54,

		LeftWin = Ext + 0x5B,
		RightWin = Ext + 0x5C,
		Menu = Ext + 0x5D,
	}

	/// <summary>
	/// The <see cref="Button"/> code of a controller <see cref="Button"/>.
	/// </summary>
	public enum Button
	{
		/// <summary>D-Pad Up.</summary>
		DpadUp = 0,
		/// <summary>D-Pad Down.</summary>
		DpadDown = 1,
		/// <summary>D-Pad Left.</summary>
		DpadLeft = 2,
		/// <summary>D-Pad Right.</summary>
		DpadRight = 3,
		/// <summary>North Button.</summary>
		North = 4,
		/// <summary>Y Button.</summary>
		Y = 4,
		/// <summary>Triangle Button.</summary>
		Triangle = 4,
		/// <summary>East Button.</summary>
		East = 5,
		/// <summary>B Button.</summary>
		B = 5,
		/// <summary>Circle Button.</summary>
		Circle = 5,
		/// <summary>South Button.</summary>
		South = 6,
		/// <summary>A Button.</summary>
		A = 6,
		/// <summary>Cross Button.</summary>
		Cross = 6,
		/// <summary>West Button.</summary>
		West = 7,
		/// <summary>X Button.</summary>
		X = 7,
		/// <summary>Square Button.</summary>
		Square = 7,
		/// <summary>Left Stick.</summary>
		LeftStick = 8,
		/// <summary>Right Stick.</summary>
		RightStick = 9,
		/// <summary>Left Shoulder.</summary>
		LeftShoulder = 10,
		/// <summary>Right Shoulder.</summary>
		RightShoulder = 11,
		/// <summary>Start Button.</summary>
		Start = 12,
		/// <summary>Select Button.</summary>
		Select = 13,
		/// <summary>Left Trigger.</summary>
		LeftTrigger = 32,
		/// <summary>Right Trigger.</summary>
		RightTrigger = 33
	}

	/// <summary>
	/// The <see cref="Mouse"/> code of a <see cref="Mouse"/> button.
	/// </summary>
	public enum Mouse
	{
		/// <summary>Left Mouse Button (on right-handed mouse).</summary>
		Left = 0,
		/// <summary>Primary Mouse Button.</summary>
		Button1 = 0,
		/// <summary>Right Mouse Button (on right-handed mouse).</summary>
		Right = 1,
		/// <summary>Secondary Mouse Button.</summary>
		Button2 = 1,
		/// <summary>Middle Mouse Button.</summary>
		Middle = 2,
		/// <summary>Middle Mouse Button.</summary>
		Button3 = 2,
		/// <summary>Forward Mouse Button.</summary>
		Forward = 3,
		/// <summary>Forward Mouse Button.</summary>
		Button4 = 3,
		/// <summary>Back Mouse Button</summary>
		Back = 4,
		/// <summary>Back Mouse Button.</summary>
		Button5 = 4
	}
    #endregion

	/// <summary>
	/// The class that can hook into external functions to act as input.
	/// </summary>
    public static class Input
    {
		// Maybe combine these key check delegates into one unified delegate instead?
		/// <summary>
		/// Handles a <see cref="Key"/> press check. If you're using anything other than Unity, you may want to convert the <see cref="Key"/> value.
		/// </summary>
		/// <param name="key">The <see cref="Key"/> to check.</param>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was pressed down this update tick. Otherwise, <see langword="false"/>.</returns>
		public delegate bool KeyPressedHandle(int key);

		/// <summary>
		/// Handles a <see cref="Key"/> release check. If you're using anything other than Unity, you may want to convert the <see cref="Key"/> value.
		/// </summary>
		/// <param name="key">The <see cref="Key"/> to check.</param>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was released this update tick. Otherwise, <see langword="false"/>.</returns>
		public delegate bool KeyReleasedHandle(int key);

		/// <summary>
		/// Handles a <see cref="Key"/> hold check. If you're using anything other than Unity, you may want to convert the <see cref="Key"/> value.
		/// </summary>
		/// <param name="key">The <see cref="Key"/> to check.</param>
		/// <returns><see langword="true"/> if the <see cref="Key"/> is being held down. Otherwise, <see langword="false"/>.</returns>
		public delegate bool KeyHeldHandle(int key);

		/// <summary>
		/// Used to run an update in an external library (usually the main engine's input) to run logic behind the scenes during a game.
		/// </summary>
		public delegate void UpdateFunc();

		/// <summary>
		/// Handles a <see cref="Key"/> press check.
		/// </summary>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was pressed down this update tick. Otherwise, <see langword="false"/>.</returns>
		public static KeyPressedHandle KeyPressHandler { get; set; }

		/// <summary>
		/// Handles a <see cref="Key"/> release check.
		/// </summary>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was released this update tick. Otherwise, <see langword="false"/>.</returns>
		public static KeyReleasedHandle KeyReleaseHandler { get; set; }

		/// <summary>
		/// Handles a <see cref="Key"/> hold check.
		/// </summary>
		/// <returns><see langword="true"/> if the <see cref="Key"/> is being held down. Otherwise, <see langword="false"/>.</returns>
		public static KeyHeldHandle KeyHoldHandler { get; set; }

		private static UpdateFunc updateFunc;

		/// <summary>
		/// Used to run an update in an external library (usually the main engine's input) to run logic behind the scenes during a game.
		/// </summary>
		public static event UpdateFunc OnUpdate { add { updateFunc += value; } remove { updateFunc -= value; } }

		/// <summary>
		/// Checks to see if the <see cref="Key"/> was pressed this tick.
		/// </summary>
		/// <param name="key">The <see cref="Key"/> to check.</param>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was pressed. Otherwise, <see langword="false"/>.</returns>
		public static bool KeyDown(Key key)
        {
			if (KeyPressHandler == null)
				return false;
			return KeyPressHandler((int)key);
        }

		/// <summary>
		/// Checks to see if the <see cref="Key"/> was released this tick.
		/// </summary>
		/// <param name="key">The <see cref="Key"/> to check.</param>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was released. Otherwise, <see langword="false"/>.</returns>
		public static bool KeyUp(Key key)
		{
			if (KeyReleaseHandler == null)
				return false;
			return KeyReleaseHandler((int)key);
		}

		/// <summary>
		/// Checks to see if the <see cref="Key"/> is being held down.
		/// </summary>
		/// <param name="key">The <see cref="Key"/> to check.</param>
		/// <returns><see langword="true"/> if the <see cref="Key"/> is being held down. Otherwise, <see langword="false"/>.</returns>
		public static bool KeyHold(Key key)
		{
			if (KeyHoldHandler == null)
				return false;
			return KeyHoldHandler((int)key);
		}

		internal static void Update()
        {
			updateFunc?.Invoke();
        }
	}
}
