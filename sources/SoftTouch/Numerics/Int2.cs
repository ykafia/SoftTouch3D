using System;

namespace SoftTouch.Numerics;

public struct Int2 : ISoftVector2<Int2, int>
{
    public int X {get;set;}
    public int Y {get;set;}

    public Int2(int value)
    {
        X = value;
        Y = value;
    }
    public Int2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static int Distance(in Int2 value)
    {
        return (int)Math.Sqrt(value.X * value.X + value.Y * value.Y);
    }

    public static Int2 New(int value)
    {
        return new(value);
    }

    public static Int2 New(int x, int y)
    {
        return new(x,y);
    }

    public static void SquareRoot(in Int2 value, out Int2 result)
    {
        result = new((int)Math.Sqrt(value.X), (int)Math.Sqrt(value.Y));
    }
}