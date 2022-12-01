using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace SoftTouch.AdditionalNumerics;

public struct UInt2 : INumber<UInt2>
{
    public int X;
    public int Y;

    public static UInt2 One => throw new NotImplementedException();

    public static int Radix => throw new NotImplementedException();

    public static UInt2 Zero => throw new NotImplementedException();

    public static UInt2 AdditiveIdentity => throw new NotImplementedException();

    public static UInt2 MultiplicativeIdentity => throw new NotImplementedException();

    public static UInt2 Abs(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static UInt2 MaxMagnitude(UInt2 x, UInt2 y)
    {
        throw new NotImplementedException();
    }

    public static UInt2 MaxMagnitudeNumber(UInt2 x, UInt2 y)
    {
        throw new NotImplementedException();
    }

    public static UInt2 MinMagnitude(UInt2 x, UInt2 y)
    {
        throw new NotImplementedException();
    }

    public static UInt2 MinMagnitudeNumber(UInt2 x, UInt2 y)
    {
        throw new NotImplementedException();
    }

    public static UInt2 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UInt2 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UInt2 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static UInt2 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt2 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt2 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt2 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UInt2 result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(UInt2 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(UInt2 other)
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

    public static UInt2 operator +(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator +(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator -(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator -(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator ++(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator --(UInt2 value)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator *(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator /(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static UInt2 operator %(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(UInt2 left, UInt2 right)
    {
        throw new NotImplementedException();
    }
}
