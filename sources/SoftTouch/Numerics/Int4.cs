using System;

namespace SoftTouch.Numerics;

public struct Int4 : ISoftVector4<Int4, int>
{
    public int X {get;set;}
    public int Y {get;set;}
    public int Z {get;set;}
    public int W {get;set;}

    public Int4(int value)
    {
        X = value;
        Y = value;
        Z = value;
        W = value;
        
    }
    public Int4(int x, int y, int z, int w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static int Distance(in Int4 value)
    {
        return (int)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
    }

    public static Int4 New(int value)
    {
        return new(value);
    }

    public static Int4 New(int x, int y)
    {
        throw new NotImplementedException();
    }
    public static Int4 New(int x, int y, int z)
    {
        throw new NotImplementedException();
    }

    public static Int4 New(int x, int y, int z, int w)
    {
        return new(x,y,z,w);
    }

    public static void SquareRoot(in Int4 value, out Int4 result)
    {
        result = new((int)Math.Sqrt(value.X), (int)Math.Sqrt(value.Y), (int)Math.Sqrt(value.Z), (int)Math.Sqrt(value.W));
    }
}