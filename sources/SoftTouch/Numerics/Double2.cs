using System;

namespace SoftTouch.Numerics;

public struct Double2 : ISoftVector2<Double2, double>
{
    public double X {get;set;}
    public double Y {get;set;}

    public Double2(double value)
    {
        X = value;
        Y = value;
    }
    public Double2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static double Distance(in Double2 value)
    {
        return (double)Math.Sqrt(value.X * value.X + value.Y * value.Y);
    }

    public static Double2 New(double value)
    {
        return new(value);
    }

    public static Double2 New(double x, double y)
    {
        return new(x,y);
    }

    public static void SquareRoot(in Double2 value, out Double2 result)
    {
        result = new((double)Math.Sqrt(value.X), (double)Math.Sqrt(value.Y));
    }
}