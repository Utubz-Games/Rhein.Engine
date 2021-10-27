/*  
 *  This Source Code Form is subject to the terms of the Mozilla Public
 *  License, v. 2.0. If a copy of the MPL was not distributed with this
 *  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *  
 *  Copyright (C) 2021 Jaiden "398utubzyt" Garcia
 */

using System;
using System.Runtime.CompilerServices;

namespace Rhein
{
	/// <summary>
	/// The type of angle you're measuring in. Usually used for trigonometry.
	/// </summary>
	public enum AngleMode
	{
		Degrees,
		Radians
	}
	
	/// <summary>
	/// A collection of <see cref="Math"/> functions and variables.
	/// </summary>
	public static class Math
	{
		/// <summary>
		/// Not a real number, but we'll use it as one anyway!
		/// </summary>
		public const float Infinity = 1f / 0f;
		/// <summary>
		/// The negative version of <see cref="Infinity"/>.
		/// </summary>
		public const float NegativeInfinity = -1f / 0f;
		/// <summary>
		/// The classic infinite decimal number used for trigonometry.
		/// </summary>
		public const float Pi = 3.14159265f;
		/// <summary>
		/// It's <see cref="Pi"/> multiplied by 2.
		/// </summary>
		public const float Tau = Pi * 2f;
		/// <summary>
		/// The smallest number you're gonna get in C#. This is usually used to check for precision errors in <see cref="float"/> values.
		/// </summary>
		public const float Epsilon = float.Epsilon;
		/// <summary>
		/// Used to convert degrees into radians through multiplication.
		/// </summary>
		public const float Deg2Rad = Pi / 180f;
		/// <summary>
		/// Used to convert radians into degrees through multiplication.
		/// </summary>
		public const float Rad2Deg = 180f / Pi;

		/// <summary>
		/// Determines if both numbers are about the same (using <see cref="Epsilon"/>).
		/// </summary>
		/// <param name="x">The first number to check.</param>
		/// <param name="y">The second number to check.</param>
		/// <returns><see langword="true"/> if both numbers are similar, otherwise <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Approx(float x, float y)
		{
			return Abs(x - y) <= Epsilon;
		}

		/// <summary>
		/// Determines if a number is about zero (using <see cref="Epsilon"/>).
		/// </summary>
		/// <param name="x">The number to check.</param>
		/// <returns><see langword="true"/> if <paramref name="x"/> is about equal to zero, otherwise <see langword="false"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool ApproxZero(float x)
		{
			return Abs(x) <= Epsilon;
		}

		/// <summary>
		/// Adds two numbers together.
		/// </summary>
		/// <param name="x">The first number to add.</param>
		/// <param name="y">The second number to add.</param>
		/// <returns>The sum of <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Add(float x, float y)
		{
			return x + y;
		}

		/// <summary>
		/// Subtracts a number from another.
		/// </summary>
		/// <param name="x">The number to subtract from.</param>
		/// <param name="y">The number to subtract by.</param>
		/// <returns>The difference between <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Subtract(float x, float y)
		{
			return x - y;
		}

		/// <summary>
		/// Multiplies two numbers together.
		/// </summary>
		/// <param name="x">The first number to multiply.</param>
		/// <param name="y">The second number to multiply.</param>
		/// <returns>The product of <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Multiply(float x, float y)
		{
			return x * y;
		}

		/// <summary>
		/// Divides a number by another.
		/// </summary>
		/// <param name="x">The number to divide.</param>
		/// <param name="y">The number to divide by.</param>
		/// <returns>The quotient of <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Divide(float x, float y)
		{
			return x / y;
		}

		/// <summary>
		/// Divides a number by another and gets the remainder.
		/// </summary>
		/// <param name="x">The number to divide.</param>
		/// <param name="y">The number to divide by.</param>
		/// <returns>The remainder of <paramref name="x"/> divided by <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Mod(float x, float y)
		{
			return x % y;
		}

		/// <summary>
		/// Divides a number by another and gets the absolute value of the remainder.
		/// </summary>
		/// <param name="x">The number to divide.</param>
		/// <param name="y">The number to divide by.</param>
		/// <returns>The absolute value of the remainder of <paramref name="x"/> divided by <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float PosMod(float x, float y)
		{
			return Abs(x % y);
		}

		/// <summary>
		/// Multiplies the number by itself.
		/// </summary>
		/// <param name="x">The number to square.</param>
		/// <returns>The product of <paramref name="x"/> multiplied by <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Square(float x)
		{
			return x * x;
		}

		/// <summary>
		/// Multiplies the number by itself two times.
		/// </summary>
		/// <param name="x">The number to cube.</param>
		/// <returns>The product of <paramref name="x"/> multiplied by <paramref name="x"/> multiplied by <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cube(float x)
		{
			return x * x * x;
		}

		/// <summary>
		/// Gets the square root of a number.
		/// </summary>
		/// <param name="x">The square.</param>
		/// <returns>The square root of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Sqrt(float x)
		{
			// Sadly, we have to use System.Math instead of System.MathF so that it's compatible with
			// older engines like Unity that are still using .NET Framework/Standard instead of .NET 5/6
			// When Unity switches to .NET 6, I'll consider fixing this.
			// -398
			return (float)System.Math.Sqrt(x);
		}

		/// <summary>
		/// Gets the cube root of a number.
		/// </summary>
		/// <param name="x">The cube.</param>
		/// <returns>The cube root of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cbrt(float x)
		{
			return (float)System.Math.Pow(x, -3f);
		}

		/// <summary>
		/// Gets the result of a number to the power of another.
		/// </summary>
		/// <param name="x">The base.</param>
		/// <param name="p">The power.</param>
		/// <returns>The result of <paramref name="x"/> to the power of <paramref name="p"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Pow(float x, float p)
		{
			return (float)System.Math.Pow(x, p);
		}

		/// <summary>
		/// Gets the root of a number to the power of another.
		/// </summary>
		/// <param name="x">The base.</param>
		/// <param name="p">The root.</param>
		/// <returns>The result of <paramref name="x"/> to the power of -<paramref name="p"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Root(float x, float p)
		{
			return (float)System.Math.Pow(x, -p);
		}

		/// <summary>
		/// Gets the exponent of a exponential.
		/// </summary>
		/// <param name="a">The exponential.</param>
		/// <param name="b">The base.</param>
		/// <returns>The Log base <paramref name="b"/> of <paramref name="a"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Log(float a, float b)
		{
			return (float)System.Math.Log(a, -b);
		}

		/// <summary>
		/// Gets the exponent of a exponential with a base of 10.
		/// </summary>
		/// <param name="a">The exponential.</param>
		/// <returns>The Log base 10 of <paramref name="a"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Log10(float a)
		{
			return (float)System.Math.Log10(a);
		}

		/// <summary>
		/// Gets the exponent of a exponential with a base of E.
		/// </summary>
		/// <param name="a">The exponential.</param>
		/// <returns>The Log base E of <paramref name="a"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float LogE(float a)
		{
			return (float)System.Math.Log(a);
		}

		/// <summary>
		/// Gets the length of two numbers using the Pythagorean theorem.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">B.</param>
		/// <returns>C, or the length of the hypotenuse.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Length(float a, float b)
		{
			return Sqrt(a * a + b * b);
		}

		/// <summary>
		/// Gets the square length of two numbers using the Pythagorean theorem.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">B.</param>
		/// <returns>C squared, or the square length of the hypotenuse.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SqrLength(float a, float b)
		{
			return a * a + b * b;
		}

		/// <summary>
		/// Gets the length of three numbers using a modified Pythagorean theorem.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">B.</param>
		/// <param name="c">C.</param>
		/// <returns>D, or the length of the hypotenuse.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Length(float a, float b, float c)
		{
			return Sqrt(a * a + b * b + c * c);
		}

		/// <summary>
		/// Gets the square length of three numbers using a modified Pythagorean theorem.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">B.</param>
		/// <param name="c">C.</param>
		/// <returns>D squared, or the square length of the hypotenuse.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SqrLength(float a, float b, float c)
		{
			return a * a + b * b + c * c;
		}

		/// <summary>
		/// Gets the minimum value of the collection of numbers.
		/// </summary>
		/// <param name="x">Value 1.</param>
		/// <param name="y">Value 2.</param>
		/// <returns>The smallest value of the collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Min(float x, float y)
		{
			return x < y ? x : y;
		}

		/// <summary>
		/// Gets the minimum value of the collection of numbers.
		/// </summary>
		/// <param name="nums">The collection.</param>
		/// <returns>The smallest value of the collection.</returns>
		public static float Min(params float[] nums)
		{
			if (nums.Length == 0)
				return 0f;

			float x = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] < x)
					x = nums[i];
			}
			
			return x;
		}

		/// <summary>
		/// Gets the maximum value of the collection of numbers.
		/// </summary>
		/// <param name="x">Value 1.</param>
		/// <param name="y">Value 2.</param>
		/// <returns>The biggest value of the collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Max(float x, float y)
		{
			return x > y ? x : y;
		}

		/// <summary>
		/// Gets the maximum value of the collection of numbers.
		/// </summary>
		/// <param name="nums">The collection.</param>
		/// <returns>The biggest value of the collection.</returns>
		public static float Max(params float[] nums)
		{
			if (nums.Length == 0)
				return 0f;

			float x = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] > x)
					x = nums[i];
			}

			return x;
		}

		/// <summary>
		/// Restricts a value between 0 and 1.
		/// </summary>
		/// <param name="x">The number to restrict.</param>
		/// <returns>The restricted value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp(float x)
		{
			return x < 0f ? 0f : (x > 1f ? 1f : x);
		}

		/// <summary>
		/// Restricts a value between 0 and the provided value.
		/// </summary>
		/// <param name="x">The number to restrict.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The restricted value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp(float x, float max)
		{
			return x < 0f ? 0f : (x > max ? max : x);
		}

		/// <summary>
		/// Restricts a value between the minimum and maximum boundaries.
		/// </summary>
		/// <param name="x">The number to restrict.</param>
		/// <param name="min">The minimum boundary.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The restricted value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp(float x, float min, float max)
		{
			return x < min ? min : (x > max ? max : x);
		}

		/// <summary>
		/// Loops a value between 0 and 1.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Loop(float x)
		{
			return x % 1f;
		}

		/// <summary>
		/// Loops a value between 0 and the provided value.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Loop(float x, float max)
		{
			return x % max;
		}

		/// <summary>
		/// Loops a value between the minimum and maximum boundaries.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <param name="min">The minimum boundary.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Loop(float x, float min, float max)
		{
			return (x % (max - min)) + min;
		}

		/// <summary>
		/// Ping-pongs a value between 0 and 1.
		/// </summary>
		/// <param name="x">The number to ping-pong.</param>
		/// <returns>The ping-ponged value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float PingPong(float x)
		{
			return x % 2f < 1f ? x : 1f - x;
		}

		/// <summary>
		/// Ping-Pongs a value between 0 and the provided value.
		/// </summary>
		/// <param name="x">The number to ping-pong.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The ping-ponged value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float PingPong(float x, float max)
		{
			return x % (max * 2f) < max ? x : max - x;
		}

		/// <summary>
		/// Ping-Pongs a value between the minimum and maximum boundaries.
		/// </summary>
		/// <param name="x">The number to ping-pong.</param>
		/// <param name="min">The minimum boundary.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The ping-ponged value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float PingPong(float x, float min, float max)
		{
			return x % ((max - min) * 2f) < max ? x + min : max - (x + min);
		}

		/// <summary>
		/// Snaps a value to the step centered at 0.
		/// </summary>
		/// <param name="x">The value to snap.</param>
		/// <param name="step">The step to snap at.</param>
		/// <returns>The snapped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Snap(float x, float step)
		{
			return Round(x / step) * step;
		}

		/// <summary>
		/// Gets the absolute value of a number.
		/// </summary>
		/// <param name="x">The number.</param>
		/// <returns>The absolute value of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Abs(float x)
		{
			return (float)System.Math.Abs(x);
		}

		/// <summary>
		/// Gets the ceiling value (rounded up) of a number.
		/// </summary>
		/// <param name="x">The number.</param>
		/// <returns>The ceiling of a <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Ceil(float x)
		{
			return (float)System.Math.Ceiling(x);
		}

		/// <summary>
		/// Gets the floor value (rounded down) of a number.
		/// </summary>
		/// <param name="x">The number.</param>
		/// <returns>The floor of a <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Floor(float x)
		{
			return (float)System.Math.Floor(x);
		}

		/// <summary>
		/// Gets the rounded value of a number.
		/// </summary>
		/// <param name="x">The number.</param>
		/// <returns>The rounded of a <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Round(float x)
		{
			return (float)System.Math.Round(x);
		}

		/// <summary>
		/// Gets the truncated value (rounded towards 0) of a number.
		/// </summary>
		/// <param name="x">The number.</param>
		/// <returns>The truncated value of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Truncate(float x)
		{
			return (int)x;
		}

		/// <summary>
		/// Gets the sign of a number.
		/// </summary>
		/// <param name="x">The number to check.</param>
		/// <returns>+1 if positive, 0 if zero, -1 if negative.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Sign(float x)
		{
			return (float)System.Math.Sign(x);
		}

		/// <summary>
		/// Linearly interpolates a number and another number by a normalized value.
		/// </summary>
		/// <param name="x">The number to interpolate.</param>
		/// <param name="y">The number to interpolate towards.</param>
		/// <param name="t">The normalized value.</param>
		/// <returns>The interpolation between <paramref name="x"/> and <paramref name="y"/> by <paramref name="t"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Lerp(float x, float y, float t)
		{
			return x * (1f - Clamp(t)) + y * Clamp(t);
		}

		/// <summary>
		/// Linearly interpolates an angle in degrees and another angle in degrees by a normalized value.
		/// </summary>
		/// <param name="x">The angle to interpolate.</param>
		/// <param name="y">The angle to interpolate towards.</param>
		/// <param name="t">The normalized value.</param>
		/// <returns>The interpolation between <paramref name="x"/> and <paramref name="y"/> by <paramref name="t"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float LerpAngle(float x, float y, float t)
		{
			return Atan2(Lerp(Sin(y), Sin(y), t), Lerp(Cos(x), Cos(x), t));
		}

		/// <summary>
		/// Linearly interpolates a number and another number by an unclamped normalized value.
		/// </summary>
		/// <param name="x">The number to interpolate.</param>
		/// <param name="y">The number to interpolate towards.</param>
		/// <param name="t">The unclamped normalized value.</param>
		/// <returns>The interpolation between <paramref name="x"/> and <paramref name="y"/> by <paramref name="t"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float LerpUnclamped(float x, float y, float t)
		{
			return x * (1f - t) + y * t;
		}

		/// <summary>
		/// Converts a radian angle to degrees.
		/// </summary>
		/// <param name="r">The angle in radians.</param>
		/// <returns>The angle in degrees.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Degrees(float r)
		{
			return r * Rad2Deg;
		}

		/// <summary>
		/// Converts a degree angle to radians.
		/// </summary>
		/// <param name="d">The angle in degrees.</param>
		/// <returns>The angle in radians.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Radians(float d)
		{
			return d * Deg2Rad;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float DegreesAngleMultiplier(AngleMode mode)
		{
			return mode == AngleMode.Degrees ? Deg2Rad : 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float RadiansAngleMultiplier(AngleMode mode)
		{
			return mode == AngleMode.Radians ? 1f : Rad2Deg;
		}

		/// <summary>
		/// Gets the sine of an angle.
		/// </summary>
		/// <param name="x">The angle.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The sine of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Sin(float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Sin(x * DegreesAngleMultiplier(mode));
		}

		/// <summary>
		/// Gets the cosine of an angle.
		/// </summary>
		/// <param name="x">The angle.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The cosine of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Cos(float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Cos(x * DegreesAngleMultiplier(mode));
		}

		/// <summary>
		/// Gets the tangent of an angle.
		/// </summary>
		/// <param name="x">The angle.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The tangent of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Tan(float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Tan(x * DegreesAngleMultiplier(mode));
		}

		/// <summary>
		/// Gets the angle of a sine.
		/// </summary>
		/// <param name="x">The sine.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The angle of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Asin(float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Asin(x) * RadiansAngleMultiplier(mode);
		}

		/// <summary>
		/// Gets the angle of a cosine.
		/// </summary>
		/// <param name="x">The cosine.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The angle of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Acos(float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Acos(x) * RadiansAngleMultiplier(mode);
		}

		/// <summary>
		/// Gets the angle of a tangent.
		/// </summary>
		/// <param name="x">The tangent.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The angle of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Atan(float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Atan(x) * RadiansAngleMultiplier(mode);
		}

		/// <summary>
		/// Gets the angle of a tangent using two values instead of one.
		/// </summary>
		/// <param name="y">The numerator.</param>
		/// <param name="x">The denominator.</param>
		/// <param name="mode">The type of angle to use.</param>
		/// <returns>The angle of the tangent <paramref name="y"/>/<paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Atan2(float y, float x, AngleMode mode = AngleMode.Degrees)
		{
			return (float)System.Math.Atan2(y, x) * RadiansAngleMultiplier(mode);
		}

		/// <summary>
		/// Adds two numbers together.
		/// </summary>
		/// <param name="x">The first number to add.</param>
		/// <param name="y">The second number to add.</param>
		/// <returns>The sum of <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Add(int x, int y)
		{
			return x + y;
		}

		/// <summary>
		/// Subtracts a number from another.
		/// </summary>
		/// <param name="x">The number to subtract from.</param>
		/// <param name="y">The number to subtract by.</param>
		/// <returns>The difference between <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Subtract(int x, int y)
		{
			return x - y;
		}

		/// <summary>
		/// Multiplies two numbers together.
		/// </summary>
		/// <param name="x">The first number to multiply.</param>
		/// <param name="y">The second number to multiply.</param>
		/// <returns>The product of <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Multiply(int x, int y)
		{
			return x * y;
		}

		/// <summary>
		/// Divides a number by another.
		/// </summary>
		/// <param name="x">The number to divide.</param>
		/// <param name="y">The number to divide by.</param>
		/// <returns>The quotient of <paramref name="x"/> and <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Divide(int x, int y)
		{
			return x / y;
		}

		/// <summary>
		/// Divides a number by another and gets the remainder.
		/// </summary>
		/// <param name="x">The number to divide.</param>
		/// <param name="y">The number to divide by.</param>
		/// <returns>The remainder of <paramref name="x"/> divided by <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Mod(int x, int y)
		{
			return x % y;
		}

		/// <summary>
		/// Divides a number by another and gets the absolute value of the remainder.
		/// </summary>
		/// <param name="x">The number to divide.</param>
		/// <param name="y">The number to divide by.</param>
		/// <returns>The absolute value of the remainder of <paramref name="x"/> divided by <paramref name="y"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int PosMod(int x, int y)
		{
			return Abs(x % y);
		}

		/// <summary>
		/// Multiplies the number by itself.
		/// </summary>
		/// <param name="x">The number to square.</param>
		/// <returns>The product of <paramref name="x"/> multiplied by <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Square(int x)
		{
			return x * x;
		}

		/// <summary>
		/// Multiplies the number by itself two times.
		/// </summary>
		/// <param name="x">The number to cube.</param>
		/// <returns>The product of <paramref name="x"/> multiplied by <paramref name="x"/> multiplied by <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Cube(int x)
		{
			return x * x * x;
		}

		/// <summary>
		/// Gets the minimum value of the collection of numbers.
		/// </summary>
		/// <param name="x">Value 1.</param>
		/// <param name="y">Value 2.</param>
		/// <returns>The smallest value of the collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Min(int x, int y)
		{
			return x < y ? x : y;
		}

		/// <summary>
		/// Gets the minimum value of the collection of numbers.
		/// </summary>
		/// <param name="nums">The collection.</param>
		/// <returns>The smallest value of the collection.</returns>
		public static int Min(params int[] nums)
		{
			if (nums.Length == 0)
				return 0;

			int x = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] < x)
					x = nums[i];
			}

			return x;
		}

		/// <summary>
		/// Gets the maximum value of the collection of numbers.
		/// </summary>
		/// <param name="x">Value 1.</param>
		/// <param name="y">Value 2.</param>
		/// <returns>The biggest value of the collection.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Max(int x, int y)
		{
			return x > y ? x : y;
		}

		/// <summary>
		/// Gets the maximum value of the collection of numbers.
		/// </summary>
		/// <param name="nums">The collection.</param>
		/// <returns>The biggest value of the collection.</returns>
		public static int Max(params int[] nums)
		{
			if (nums.Length == 0)
				return 0;

			int x = nums[0];

			for (int i = 1; i < nums.Length; i++)
			{
				if (nums[i] > x)
					x = nums[i];
			}

			return x;
		}

		/// <summary>
		/// Restricts a value between 0 and 1.
		/// </summary>
		/// <param name="x">The number to restrict.</param>
		/// <returns>The restricted value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Clamp(int x)
		{
			return x < 0 ? 0 : (x > 1 ? 1 : x);
		}

		/// <summary>
		/// Restricts a value between 0 and the provided value.
		/// </summary>
		/// <param name="x">The number to restrict.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The restricted value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Clamp(int x, int max)
		{
			return x < 0 ? 0 : (x > max ? max : x);
		}

		/// <summary>
		/// Restricts a value between the minimum and maximum boundaries.
		/// </summary>
		/// <param name="x">The number to restrict.</param>
		/// <param name="min">The minimum boundary.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The restricted value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Clamp(int x, int min, int max)
		{
			return x < min ? min : (x > max ? max : x);
		}

		/// <summary>
		/// Loops a value between 0 and 1.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Loop(int x)
		{
			return x % 1;
		}

		/// <summary>
		/// Loops a value between 0 and the provided value.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Loop(int x, int max)
		{
			return x % max;
		}

		/// <summary>
		/// Loops a value between the minimum and maximum boundaries.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <param name="min">The minimum boundary.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Loop(int x, int min, int max)
		{
			return (x % (max - min)) + min;
		}

		/// <summary>
		/// Ping-pongs a value between 0 and 1.
		/// </summary>
		/// <param name="x">The number to ping-pong.</param>
		/// <returns>The ping-ponged value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int PingPong(int x)
		{
			return x % 2 < 1 ? x : 1 - x;
		}

		/// <summary>
		/// Loops a value between 0 and the provided value.
		/// </summary>
		/// <param name="x">The number to loop.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The looped value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int PingPong(int x, int max)
		{
			return x % (max * 2) < max ? x : max - x;
		}

		/// <summary>
		/// Ping-Pongs a value between the minimum and maximum boundaries.
		/// </summary>
		/// <param name="x">The number to ping-pong.</param>
		/// <param name="min">The minimum boundary.</param>
		/// <param name="max">The maximum boundary.</param>
		/// <returns>The ping-ponged value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int PingPong(int x, int min, int max)
		{
			return x % ((max - min) * 2) < max ? x + min : max - (x + min);
		}

		/// <summary>
		/// Gets the absolute value of a number.
		/// </summary>
		/// <param name="x">The number.</param>
		/// <returns>The absolute value of <paramref name="x"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Abs(int x)
		{
			return (int)Abs((float)x);
		}

		/// <summary>
		/// Gets the sign of a number.
		/// </summary>
		/// <param name="x">The number to check.</param>
		/// <returns>+1 if positive, 0 if zero, -1 if negative.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Sign(int x)
		{
			return (int)Sign((float)x);
		}
	}
}
