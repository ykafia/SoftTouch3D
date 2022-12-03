using System;

namespace SoftTouch.Numerics;

public struct Long4 : ISoftVector4<Long4, long>
{
    public long X {get;set;}
    public long Y {get;set;}
    public long Z {get;set;}
    public long W {get;set;}

    public Long4(long value)
    {
        X = value;
        Y = value;
        Z = value;
        W = value;
        
    }
    public Long4(long x, long y, long z, long w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static long Distance(in Long4 value)
    {
        return (long)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
    }

    public static Long4 New(long value)
    {
        return new(value);
    }

    public static Long4 New(long x, long y)
    {
        throw new NotImplementedException();
    }
    public static Long4 New(long x, long y, long z)
    {
        throw new NotImplementedException();
    }

    public static Long4 New(long x, long y, long z, long w)
    {
        return new(x,y,z,w);
    }

    public static void SquareRoot(in Long4 value, out Long4 result)
    {
        result = new((long)Math.Sqrt(value.X), (long)Math.Sqrt(value.Y), (long)Math.Sqrt(value.Z), (long)Math.Sqrt(value.W));
    }
}