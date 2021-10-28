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
		/// <summary>None.</summary>
		None = 0,
		/// <summary>Space.</summary>
		Space = 1,
		/// <summary>Enter.</summary>
		Enter = 2,
		/// <summary>Tab.</summary>
		Tab = 3,
		/// <summary>`</summary>
		Backquote = 4,
		/// <summary>'</summary>
		Quote = 5,
		/// <summary>;</summary>
		Semicolon = 6,
		/// <summary>,</summary>
		Comma = 7,
		/// <summary>.</summary>
		Period = 8,
		/// <summary>/</summary>
		Slash = 9,
		/// <summary>\</summary>
		Backslash = 10,
		/// <summary>[</summary>
		LeftBracket = 11,
		/// <summary>]</summary>
		RightBracket = 12,
		/// <summary>-</summary>
		Minus = 13,
		/// <summary>=</summary>
		Equals = 14,
		/// <summary>A</summary>
		A = 15,
		/// <summary>B</summary>
		B = 16,
		/// <summary>C</summary>
		C = 17,
		/// <summary>D</summary>
		D = 18,
		/// <summary>E</summary>
		E = 19,
		/// <summary>F</summary>
		F = 20,
		/// <summary>G</summary>
		G = 21,
		/// <summary>H</summary>
		H = 22,
		/// <summary>I</summary>
		I = 23,
		/// <summary>J</summary>
		J = 24,
		/// <summary>K</summary>
		K = 25,
		/// <summary>L</summary>
		L = 26,
		/// <summary>M</summary>
		M = 27,
		/// <summary>N</summary>
		N = 28,
		/// <summary>O</summary>
		O = 29,
		/// <summary>P</summary>
		P = 30,
		/// <summary>Q</summary>
		Q = 31,
		/// <summary>R</summary>
		R = 32,
		/// <summary>S</summary>
		S = 33,
		/// <summary>T</summary>
		T = 34,
		/// <summary>U</summary>
		U = 35,
		/// <summary>V</summary>
		V = 36,
		/// <summary>W</summary>
		W = 37,
		/// <summary>X</summary>
		X = 38,
		/// <summary>Y</summary>
		Y = 39,
		/// <summary>Z</summary>
		Z = 40,
		/// <summary>1</summary>
		Digit1 = 41,
		/// <summary>2</summary>
		Digit2 = 42,
		/// <summary>3</summary>
		Digit3 = 43,
		/// <summary>4</summary>
		Digit4 = 44,
		/// <summary>5</summary>
		Digit5 = 45,
		/// <summary>6</summary>
		Digit6 = 46,
		/// <summary>7</summary>
		Digit7 = 47,
		/// <summary>8</summary>
		Digit8 = 48,
		/// <summary>9</summary>
		Digit9 = 49,
		/// <summary>0</summary>
		Digit0 = 50,
		/// <summary>Left Shift.</summary>
		LeftShift = 51,
		/// <summary>Right Shift.</summary>
		RightShift = 52,
		/// <summary>Left Alt.</summary>
		LeftAlt = 53,
		/// <summary>Right Alt.</summary>
		RightAlt = 54,
		/// <summary>Alt Gr.</summary>
		AltGr = 54,
		/// <summary>Left Control.</summary>
		LeftCtrl = 55,
		/// <summary>Right Control.</summary>
		RightCtrl = 56,
		/// <summary>Left Meta.</summary>
		LeftMeta = 57,
		/// <summary>Left Windows.</summary>
		LeftWindows = 57,
		/// <summary>Left Apple.</summary>
		LeftApple = 57,
		/// <summary>Left Command.</summary>
		LeftCommand = 57,
		/// <summary>Right Meta.</summary>
		RightMeta = 58,
		/// <summary>Right Windows.</summary>
		RightWindows = 58,
		/// <summary>Right Apple.</summary>
		RightApple = 58,
		/// <summary>Right Command.</summary>
		RightCommand = 58,
		/// <summary>Context Menu.</summary>
		ContextMenu = 59,
		/// <summary>Escape.</summary>
		Escape = 60,
		/// <summary>Left.</summary>
		LeftArrow = 61,
		/// <summary>Right.</summary>
		RightArrow = 62,
		/// <summary>Up.</summary>
		UpArrow = 63,
		/// <summary>Down.</summary>
		DownArrow = 64,
		/// <summary>Backspace.</summary>
		Backspace = 65,
		/// <summary>Page Down.</summary>
		PageDown = 66,
		/// <summary>Page Up.</summary>
		PageUp = 67,
		/// <summary>Home.</summary>
		Home = 68,
		/// <summary>End.</summary>
		End = 69,
		/// <summary>Insert.</summary>
		Insert = 70,
		/// <summary>Delete.</summary>
		Delete = 71,
		/// <summary>Capslock.</summary>
		CapsLock = 72,
		/// <summary>Num Lock.</summary>
		NumLock = 73,
		/// <summary>Print Screen.</summary>
		PrintScreen = 74,
		/// <summary>Scroll Lock.</summary>
		ScrollLock = 75,
		/// <summary>Pause.</summary>
		Pause = 76,
		/// <summary>Num Enter</summary>
		NumpadEnter = 77,
		/// <summary>Num /</summary>
		NumpadDivide = 78,
		/// <summary>Num *</summary>
		NumpadMultiply = 79,
		/// <summary>Num +</summary>
		NumpadPlus = 80,
		/// <summary>Num -</summary>
		NumpadMinus = 81,
		/// <summary>Num .</summary>
		NumpadPeriod = 82,
		/// <summary>Num =</summary>
		NumpadEquals = 83,
		/// <summary>Num 0</summary>
		Numpad0 = 84,
		/// <summary>Num 1</summary>
		Numpad1 = 85,
		/// <summary>Num 2</summary>
		Numpad2 = 86,
		/// <summary>Num 3</summary>
		Numpad3 = 87,
		/// <summary>Num 4</summary>
		Numpad4 = 88,
		/// <summary>Num 5</summary>
		Numpad5 = 89,
		/// <summary>Num 6</summary>
		Numpad6 = 90,
		/// <summary>Num 7</summary>
		Numpad7 = 91,
		/// <summary>Num 8</summary>
		Numpad8 = 92,
		/// <summary>Num 9</summary>
		Numpad9 = 93,
		/// <summary>F1</summary>
		F1 = 94,
		/// <summary>F2</summary>
		F2 = 95,
		/// <summary>F3</summary>
		F3 = 96,
		/// <summary>F4</summary>
		F4 = 97,
		/// <summary>F5</summary>
		F5 = 98,
		/// <summary>F6</summary>
		F6 = 99,
		/// <summary>F7</summary>
		F7 = 100,
		/// <summary>F8</summary>
		F8 = 101,
		/// <summary>F9</summary>
		F9 = 102,
		/// <summary>F10</summary>
		F10 = 103,
		/// <summary>F11</summary>
		F11 = 104,
		/// <summary>F12</summary>
		F12 = 105,
		/// <summary>OEM 1</summary>
		OEM1 = 106,
		/// <summary>OEM 2</summary>
		OEM2 = 107,
		/// <summary>OEM 3</summary>
		OEM3 = 108,
		/// <summary>OEM 4</summary>
		OEM4 = 109,
		/// <summary>OEM 5</summary>
		OEM5 = 110,
		/// <summary>IME Selected</summary>
		IMESelected = 111
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
		/// Handles a <see cref="Key"/> press check. If you're using anything other than Unity, you may want to convert the <see cref="Key"/> value.
		/// </summary>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was pressed down this update tick. Otherwise, <see langword="false"/>.</returns>
		public static KeyPressedHandle KeyPressHandler { get; set; }

		/// <summary>
		/// Handles a <see cref="Key"/> release check. If you're using anything other than Unity, you may want to convert the <see cref="Key"/> value.
		/// </summary>
		/// <returns><see langword="true"/> if the <see cref="Key"/> was released this update tick. Otherwise, <see langword="false"/>.</returns>
		public static KeyReleasedHandle KeyReleaseHandler { get; set; }

		/// <summary>
		/// Handles a <see cref="Key"/> hold check. If you're using anything other than Unity, you may want to convert the <see cref="Key"/> value.
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
