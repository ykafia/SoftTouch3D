using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace SoftTouch.AdditionalNumerics;

public struct Int3 : INumber<Int3>
{
    public int X;
    public int Y;
    public int Z;

    public static Int3 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static Int3 Zero => throw new NotImplementedException();

    public static Int3 AdditiveIdentity => throw new NotImplementedException();

    public static Int3 MultiplicativeIdentity => throw new NotImplementedException();

    public static Int3 Abs(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static Int3 MaxMagnitude(Int3 x, Int3 y)
    {
        throw new NotImplementedException();
    }

    public static Int3 MaxMagnitudeNumber(Int3 x, Int3 y)
    {
        throw new NotImplementedException();
    }

    public static Int3 MinMagnitude(Int3 x, Int3 y)
    {
        throw new NotImplementedException();
    }

    public static Int3 MinMagnitudeNumber(Int3 x, Int3 y)
    {
        throw new NotImplementedException();
    }

    public static Int3 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int3 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int3 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int3 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Int3 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Int3 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Int3 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Int3 result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Int3 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Int3 other)
    {
        throw new NotImplementedException();
    }

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator +(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator +(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator -(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator -(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator ++(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator --(Int3 value)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator *(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator /(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static Int3 operator %(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Int3 left, Int3 right)
    {
        throw new NotImplementedException();
    }
}
