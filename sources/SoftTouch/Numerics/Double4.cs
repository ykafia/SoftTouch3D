using System;

namespace SoftTouch.Numerics;

public struct Double4 : ISoftVector4<Double4, double>
{
    public double X {get;set;}
    public double Y {get;set;}
    public double Z {get;set;}
    public double W {get;set;}

    public Double4(double value)
    {
        X = value;
        Y = value;
        Z = value;
        W = value;
        
    }
    public Double4(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static double Distance(in Double4 value)
    {
        return (double)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
    }

    public static Double4 New(double value)
    {
        return new(value);
    }

    public static Double4 New(double x, double y)
    {
        throw new NotImplementedException();
    }
    public static Double4 New(double x, double y, double z)
    {
        throw new NotImplementedException();
    }

    public static Double4 New(double x, double y, double z, double w)
    {
        return new(x,y,z,w);
    }

    public static void SquareRoot(in Double4 value, out Double4 result)
    {
        result = new((double)Math.Sqrt(value.X), (double)Math.Sqrt(value.Y), (double)Math.Sqrt(value.Z), (double)Math.Sqrt(value.W));
    }
}