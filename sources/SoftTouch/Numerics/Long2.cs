using System;

namespace SoftTouch.Numerics;

public struct Long2 : ISoftVector2<Long2, long>
{
    public long X {get;set;}
    public long Y {get;set;}

    public Long2(long value)
    {
        X = value;
        Y = value;
    }
    public Long2(long x, long y)
    {
        X = x;
        Y = y;
    }

    public static long Distance(in Long2 value)
    {
        return (long)Math.Sqrt(value.X * value.X + value.Y * value.Y);
    }

    public static Long2 New(long value)
    {
        return new(value);
    }

    public static Long2 New(long x, long y)
    {
        return new(x,y);
    }

    public static void SquareRoot(in Long2 value, out Long2 result)
    {
        result = new((long)Math.Sqrt(value.X), (long)Math.Sqrt(value.Y));
    }
}