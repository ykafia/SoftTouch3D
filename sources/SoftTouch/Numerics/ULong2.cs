using System;

namespace SoftTouch.Numerics;

public struct ULong2 : ISoftVector2<ULong2, ulong>
{
    public ulong X {get;set;}
    public ulong Y {get;set;}

    public ULong2(ulong value)
    {
        X = value;
        Y = value;
    }
    public ULong2(ulong x, ulong y)
    {
        X = x;
        Y = y;
    }

    public static ulong Distance(in ULong2 value)
    {
        return (ulong)Math.Sqrt(value.X * value.X + value.Y * value.Y);
    }

    public static ULong2 New(ulong value)
    {
        return new(value);
    }

    public static ULong2 New(ulong x, ulong y)
    {
        return new(x,y);
    }

    public static void SquareRoot(in ULong2 value, out ULong2 result)
    {
        result = new((ulong)Math.Sqrt(value.X), (ulong)Math.Sqrt(value.Y));
    }
}