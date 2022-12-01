using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace SoftTouch.AdditionalNumerics;

public struct Int2 : INumber<Int2>
{
    public int X;
    public int Y;

    public Int2(int v)
    {
        X = v;
        Y = v;
    }
    public Int2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Int2 One => new(1,1);

    public static int Radix => 10;

    public static Int2 Zero => new(0,0);

    public static Int2 AdditiveIdentity => One;

    public static Int2 MultiplicativeIdentity => One;

    public static Int2 Abs(Int2 value)
    {
        return new(Math.Abs(value.X),Math.Abs(value.X));
    }

    public static bool IsCanonical(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsComplexNumber(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsEvenInteger(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsFinite(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsImaginaryNumber(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInfinity(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsInteger(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNaN(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegative(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNegativeInfinity(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsNormal(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsOddInteger(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositive(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsPositiveInfinity(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsRealNumber(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsSubnormal(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static bool IsZero(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static Int2 MaxMagnitude(Int2 x, Int2 y)
    {
        throw new NotImplementedException();
    }

    public static Int2 MaxMagnitudeNumber(Int2 x, Int2 y)
    {
        throw new NotImplementedException();
    }

    public static Int2 MinMagnitude(Int2 x, Int2 y)
    {
        throw new NotImplementedException();
    }

    public static Int2 MinMagnitudeNumber(Int2 x, Int2 y)
    {
        throw new NotImplementedException();
    }

    public static Int2 Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int2 Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int2 Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static Int2 Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Int2 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out Int2 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Int2 result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Int2 result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(Int2 other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Int2 other)
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

    public static Int2 operator +(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator +(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator -(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator -(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator ++(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator --(Int2 value)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator *(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator /(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static Int2 operator %(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(Int2 left, Int2 right)
    {
        throw new NotImplementedException();
    }
}
