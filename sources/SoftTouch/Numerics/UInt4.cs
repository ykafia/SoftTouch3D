using System;

namespace SoftTouch.Numerics;

public struct UInt4 : ISoftVector4<UInt4, uint>
{
    public uint X {get;set;}
    public uint Y {get;set;}
    public uint Z {get;set;}
    public uint W {get;set;}

    public UInt4(uint value)
    {
        X = value;
        Y = value;
        Z = value;
        W = value;
        
    }
    public UInt4(uint x, uint y, uint z, uint w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static uint Distance(in UInt4 value)
    {
        return (uint)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
    }

    public static UInt4 New(uint value)
    {
        return new(value);
    }

    public static UInt4 New(uint x, uint y)
    {
        throw new NotImplementedException();
    }
    public static UInt4 New(uint x, uint y, uint z)
    {
        throw new NotImplementedException();
    }

    public static UInt4 New(uint x, uint y, uint z, uint w)
    {
        return new(x,y,z,w);
    }

    public static void SquareRoot(in UInt4 value, out UInt4 result)
    {
        result = new((uint)Math.Sqrt(value.X), (uint)Math.Sqrt(value.Y), (uint)Math.Sqrt(value.Z), (uint)Math.Sqrt(value.W));
    }
}