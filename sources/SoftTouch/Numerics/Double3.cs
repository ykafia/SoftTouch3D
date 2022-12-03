using System;

namespace SoftTouch.Numerics;

public struct Double3 : ISoftVector3<Double3, double>
{
    public double X {get;set;}
    public double Y {get;set;}
    public double Z {get;set;}

    public Double3(double value)
    {
        X = value;
        Y = value;
        Z = value;
        
    }
    public Double3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static double Distance(in Double3 value)
    {
        return (double)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
    }

    public static Double3 New(double value)
    {
        return new(value);
    }

    public static Double3 New(double x, double y)
    {
        throw new NotImplementedException();
    }

    public static Double3 New(double x, double y, double z)
    {
        return new(x,y,z);
    }

    public static void SquareRoot(in Double3 value, out Double3 result)
    {
        result = new((double)Math.Sqrt(value.X), (double)Math.Sqrt(value.Y), (double)Math.Sqrt(value.Z));
    }
}