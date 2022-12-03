using System;

namespace SoftTouch.Numerics;

public struct ULong4 : ISoftVector4<ULong4, ulong>
{
    public ulong X {get;set;}
    public ulong Y {get;set;}
    public ulong Z {get;set;}
    public ulong W {get;set;}

    public ULong4(ulong value)
    {
        X = value;
        Y = value;
        Z = value;
        W = value;
        
    }
    public ULong4(ulong x, ulong y, ulong z, ulong w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static ulong Distance(in ULong4 value)
    {
        return (ulong)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
    }

    public static ULong4 New(ulong value)
    {
        return new(value);
    }

    public static ULong4 New(ulong x, ulong y)
    {
        throw new NotImplementedException();
    }
    public static ULong4 New(ulong x, ulong y, ulong z)
    {
        throw new NotImplementedException();
    }

    public static ULong4 New(ulong x, ulong y, ulong z, ulong w)
    {
        return new(x,y,z,w);
    }

    public static void SquareRoot(in ULong4 value, out ULong4 result)
    {
        result = new((ulong)Math.Sqrt(value.X), (ulong)Math.Sqrt(value.Y), (ulong)Math.Sqrt(value.Z), (ulong)Math.Sqrt(value.W));
    }
}