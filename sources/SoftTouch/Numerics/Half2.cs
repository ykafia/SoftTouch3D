using System;

namespace SoftTouch.Numerics;

public struct Half2 : ISoftVector2<Half2, Half>
{
    public Half X {get;set;}
    public Half Y {get;set;}

    public Half2(Half value)
    {
        X = value;
        Y = value;
    }
    public Half2(Half x, Half y)
    {
        X = x;
        Y = y;
    }

    public static Half Distance(in Half2 value)
    {
        return (Half)MathF.Sqrt((float)(value.X * value.X + value.Y * value.Y));
    }

    public static Half2 New(Half value)
    {
        return new(value);
    }

    public static Half2 New(Half x, Half y)
    {
        return new(x,y);
    }

    public static void SquareRoot(in Half2 value, out Half2 result)
    {
        result = new((Half)MathF.Sqrt((float)value.X), (Half)MathF.Sqrt((float)value.Y));
    }
}