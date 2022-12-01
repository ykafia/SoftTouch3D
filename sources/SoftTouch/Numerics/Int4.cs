using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace SoftTouch.AdditionalNumerics;

public struct Int4 : INumber<Int4>
{
    public int X;
    public int Y;
    public int Z;
    public int W;

    public static Int4 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static Int4 Zero => throw new NotImplementedException();

    public static Int4 AdditiveIdentity => throw new NotImplementedException();

    public static Int4 MultiplicativeIdentity => throw new NotImplementedException();

    public static Int4 Abs(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static Int4 MaxMagnitude(Int4 x, Int4 y)
    {
        throw new NotImplementedException();
    }

    public static Int4 MaxMagnitudeNumber(Int4 x, Int4 y)
    {
        throw new NotImplementedException();
    }

    public static Int4 MinMagnitude(Int4 x, Int4 y)
    {
        throw new NotImplementedException();
    }

    public static Int4 MinMagnitudeNumber(Int4 x, Int4 y)
    {
        throw new NotImplementedException();
    }

    public static Int4 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int4 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int4 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int4 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Int4 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Int4 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Int4 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Int4 result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Int4 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Int4 other)
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

    public static Int4 operator +(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator +(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator -(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator -(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator ++(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator --(Int4 value)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator *(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator /(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static Int4 operator %(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Int4 left, Int4 right)
    {
        throw new NotImplementedException();
    }
}
