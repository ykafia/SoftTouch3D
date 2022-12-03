using System.Numerics;

namespace SoftTouch.Numerics;

internal interface ISoftVector3<T, Num> : ISoftVector2<T, Num>
    where T :
        struct,
        ISoftVector3<T, Num>
    where Num : INumber<Num>
{
    public Num Z {get;set;}
    public static abstract T New(Num x, Num y, Num z);
    public static new void Abs(in T value, out T result)
    {
        result = T.New(
            Num.Abs(value.X), 
            Num.Abs(value.Y),
            Num.Abs(value.Z)
        );
    }

    public static new void Add(in T left, Num scalar, out T result)
    {
        result = T.New(
            left.X + scalar,
            left.Y + scalar,
            left.Z + scalar
        );
    }
    public static new void Add(in T left, in T right, out T result)
    {
        result = T.New(
            left.X + right.X,
            left.Y + right.Y,
            left.Z + right.Z
        );
    }

    public static new void Clamp(in T value, in T min, in T max, out T result)
    {
        result = T.New(
            Num.MaxMagnitude(Num.MinMagnitude(value.X,max.X), min.X),
            Num.MaxMagnitude(Num.MinMagnitude(value.Y,max.Y), min.Y),
            Num.MaxMagnitude(Num.MinMagnitude(value.Z,max.Z), min.Z)
        );
    }
    public static new Num DistanceSquared(in T value)
    {
        return value.X * value.X + value.Y * value.Y + value.Z * value.Z;
    }
    public static new void Divide(Num scalar, in T value, out T result)
    {
        result = T.New(
            scalar / value.X,
            scalar / value.Y,
            scalar / value.Z
        );
    }
    public static new void Divide(in T value, Num scalar, out T result)
    {
        result = T.New(
            value.X / scalar,
            value.Y / scalar,
            value.Z / scalar
        );
    }
    public static new void Divide(in T left, in T right, out T result)
    {
        result = T.New(
            left.X / right.X,
            left.Y / right.Y,
            left.Z / right.Z
        );
    }
    public static new Num Dot(in T left, in T right)
    {
        return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
    }
    public static new void Multiply(in T value, Num scalar, out T result)
    {
        result = T.New(
            value.X * scalar,
            value.Y * scalar,
            value.Z * scalar
        );
    }
    public static new void Multiply(in T left, in T right, out T result)
    {
        result = T.New(
            left.X * right.X,
            left.Y * right.Y,
            left.Z * right.Z
        );
    }
    public static new void Negate(in T value, out T result)
    {
        result = T.New(
            -value.X,
            -value.Y,
            -value.Z
        );
    }
    public static new void Normalize(in T value, out T result)
    {
        var x = value.X;
        var y = value.Y;
        var z = value.Z;
        result = T.New(
            x < -Num.One ? -Num.One : x > Num.One ? Num.One : x, 
            x < -Num.One ? -Num.One : x > Num.One ? Num.One : y,
            z < -Num.One ? -Num.One : z > Num.One ? Num.One : z 
        );
    }
    public static new void Reflect(in T vector, in T normal, out T result)
    {
        Num dot = T.Dot(vector,normal);
        result = T.New(
            vector.X - (Num.One + Num.One) * dot * normal.X,
            vector.Y - (Num.One + Num.One) * dot * normal.Y,
            vector.Z - (Num.One + Num.One) * dot * normal.Z
        );
    }
    
    public static new void Subtract(in T left, Num scalar, out T result)
    {
        result = T.New(
            left.X - scalar,
            left.Y - scalar,
            left.Z - scalar
        );
    }
    public static new void Subtract(Num scalar, in T left, out T result)
    {
        result = T.New(
            scalar - left.X,
            scalar - left.Y,
            scalar - left.Z
        );
    }
    public static new void Subtract(in T left, in T right, out T result)
    {
        result = T.New(
            left.X - right.X,
            left.Y - right.Y,
            left.Z - right.Z
        );
    }

    public abstract void Cross(T left, T right, out T result);
}