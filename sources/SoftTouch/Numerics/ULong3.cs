using System;

namespace SoftTouch.Numerics;

public struct ULong3 : ISoftVector3<ULong3, ulong>
{
    public ulong X {get;set;}
    public ulong Y {get;set;}
    public ulong Z {get;set;}

    public ULong3(ulong value)
    {
        X = value;
        Y = value;
        Z = value;
        
    }
    public ULong3(ulong x, ulong y, ulong z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static ulong Distance(in ULong3 value)
    {
        return (ulong)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
    }

    public static ULong3 New(ulong value)
    {
        return new(value);
    }

    public static ULong3 New(ulong x, ulong y)
    {
        throw new NotImplementedException();
    }

    public static ULong3 New(ulong x, ulong y, ulong z)
    {
        return new(x,y,z);
    }

    public static void SquareRoot(in ULong3 value, out ULong3 result)
    {
        result = new((ulong)Math.Sqrt(value.X), (ulong)Math.Sqrt(value.Y), (ulong)Math.Sqrt(value.Z));
    }
}