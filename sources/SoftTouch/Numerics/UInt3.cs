using System;

namespace SoftTouch.Numerics;

public struct UInt3 : ISoftVector3<UInt3, uint>
{
    public uint X {get;set;}
    public uint Y {get;set;}
    public uint Z {get;set;}

    public UInt3(uint value)
    {
        X = value;
        Y = value;
        Z = value;
        
    }
    public UInt3(uint x, uint y, uint z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static uint Distance(in UInt3 value)
    {
        return (uint)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
    }

    public static UInt3 New(uint value)
    {
        return new(value);
    }

    public static UInt3 New(uint x, uint y)
    {
        throw new NotImplementedException();
    }

    public static UInt3 New(uint x, uint y, uint z)
    {
        return new(x,y,z);
    }

    public static void SquareRoot(in UInt3 value, out UInt3 result)
    {
        result = new((uint)Math.Sqrt(value.X), (uint)Math.Sqrt(value.Y), (uint)Math.Sqrt(value.Z));
    }
}