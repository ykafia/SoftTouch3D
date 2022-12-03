using System;

namespace SoftTouch.Numerics;

public struct UInt2 : ISoftVector2<UInt2, uint>
{
    public uint X {get;set;}
    public uint Y {get;set;}

    public UInt2(uint value)
    {
        X = value;
        Y = value;
    }
    public UInt2(uint x, uint y)
    {
        X = x;
        Y = y;
    }

    public static uint Distance(in UInt2 value)
    {
        return (uint)Math.Sqrt(value.X * value.X + value.Y * value.Y);
    }

    public static UInt2 New(uint value)
    {
        return new(value);
    }

    public static UInt2 New(uint x, uint y)
    {
        return new(x,y);
    }

    public static void SquareRoot(in UInt2 value, out UInt2 result)
    {
        result = new((uint)Math.Sqrt(value.X), (uint)Math.Sqrt(value.Y));
    }
}