using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace SoftTouch.AdditionalNumerics;

public struct UInt4 : INumber<UInt4>
{
    public int X;
    public int Y;
    public int Z;
    public int W;

    public static UInt4 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static UInt4 Zero => throw new NotImplementedException();

    public static UInt4 AdditiveIdentity => throw new NotImplementedException();

    public static UInt4 MultiplicativeIdentity => throw new NotImplementedException();

    public static UInt4 Abs(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static UInt4 MaxMagnitude(UInt4 x, UInt4 y)
    {
        throw new NotImplementedException();
    }

    public static UInt4 MaxMagnitudeNumber(UInt4 x, UInt4 y)
    {
        throw new NotImplementedException();
    }

    public static UInt4 MinMagnitude(UInt4 x, UInt4 y)
    {
        throw new NotImplementedException();
    }

    public static UInt4 MinMagnitudeNumber(UInt4 x, UInt4 y)
    {
        throw new NotImplementedException();
    }

    public static UInt4 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UInt4 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UInt4 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UInt4 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt4 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt4 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt4 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt4 result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UInt4 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UInt4 other)
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

    public static UInt4 operator +(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator +(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator -(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator -(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator ++(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator --(UInt4 value)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator *(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator /(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static UInt4 operator %(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UInt4 left, UInt4 right)
    {
        throw new NotImplementedException();
    }
}