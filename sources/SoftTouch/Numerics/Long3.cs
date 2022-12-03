using System;

namespace SoftTouch.Numerics;

public struct Long3 : ISoftVector3<Long3, long>
{
    public long X {get;set;}
    public long Y {get;set;}
    public long Z {get;set;}

    public Long3(long value)
    {
        X = value;
        Y = value;
        Z = value;
        
    }
    public Long3(long x, long y, long z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static long Distance(in Long3 value)
    {
        return (long)Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
    }

    public static Long3 New(long value)
    {
        return new(value);
    }

    public static Long3 New(long x, long y)
    {
        throw new NotImplementedException();
    }

    public static Long3 New(long x, long y, long z)
    {
        return new(x,y,z);
    }

    public static void SquareRoot(in Long3 value, out Long3 result)
    {
        result = new((long)Math.Sqrt(value.X), (long)Math.Sqrt(value.Y), (long)Math.Sqrt(value.Z));
    }
}