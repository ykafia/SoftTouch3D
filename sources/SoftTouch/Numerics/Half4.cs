using System;

namespace SoftTouch.Numerics;

public struct Half4 : ISoftVector4<Half4, Half>
{
    public Half X {get;set;}
    public Half Y {get;set;}
    public Half Z {get;set;}
    public Half W {get;set;}

    public Half4(Half value)
    {
        X = value;
        Y = value;
        Z = value;
        W = value;
    }
    public Half4(Half x, Half y, Half z, Half w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static Half Distance(in Half4 value)
    {
        return (Half)MathF.Sqrt((float)(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W));
    }
    

    public static Half4 New(Half value)
    {
        return new(value);
    }
    public static Half4 New(Half x, Half y)
    {
        throw new NotImplementedException();
    }
    public static Half4 New(Half x, Half y, Half z)
    {
        throw new NotImplementedException();
    }

    public static Half4 New(Half x, Half y, Half z, Half w)
    {
        return new(x,y,z,w);
    }

    public static void SquareRoot(in Half4 value, out Half4 result)
    {
        result = new((Half)MathF.Sqrt((float)value.X), (Half)MathF.Sqrt((float)value.Y), (Half)MathF.Sqrt((float)value.Z), (Half)MathF.Sqrt((float)value.W));
    }
}