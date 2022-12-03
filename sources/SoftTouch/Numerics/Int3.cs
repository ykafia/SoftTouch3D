using System;

namespace SoftTouch.Numerics;

public struct Int3 : ISoftVector3<Int3, int>
{
    public int X {get;set;}
    public int Y {get;set;}
    public int Z {get;set;}

    public Int3(int value)
    {
        X = value;
        Y = value;
        Z = value;
        
    }
    public Int3(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static int Distance(in Int3 value)
    {
        return (int)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
    }

    public static Int3 New(int value)
    {
        return new(value);
    }

    public static Int3 New(int x, int y)
    {
        throw new NotImplementedException();
    }

    public static Int3 New(int x, int y, int z)
    {
        return new(x,y,z);
    }

    public static void SquareRoot(in Int3 value, out Int3 result)
    {
        result = new((int)Math.Sqrt(value.X), (int)Math.Sqrt(value.Y), (int)Math.Sqrt(value.Z));
    }
}