using System;

namespace SoftTouch.Numerics;

public struct Half3 : ISoftVector3<Half3, Half>
{
    public Half X {get;set;}
    public Half Y {get;set;}
    public Half Z {get;set;}

    public Half3(Half value)
    {
        X = value;
        Y = value;
        Z = value;
        
    }
    public Half3(Half x, Half y, Half z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Half Distance(in Half3 value)
    {
        return (Half)MathF.Sqrt((float)(value.X * value.X + value.Y * value.Y + value.Z * value.Z));
    }

    public static Half3 New(Half value)
    {
        return new(value);
    }

    public static Half3 New(Half x, Half y)
    {
        throw new NotImplementedException();
    }

    public static Half3 New(Half x, Half y, Half z)
    {
        return new(x,y,z);
    }

    public static void SquareRoot(in Half3 value, out Half3 result)
    {
        result = new((Half)Math.Sqrt((float)value.X), (Half)Math.Sqrt((float)value.Y), (Half)Math.Sqrt((float)value.Z));
    }
}