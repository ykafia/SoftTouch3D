using System;
using System.Numerics;

namespace SoftTouch.Numerics;

internal interface ISoftVector2<T, Num> : IEquatable<T>
    where T :
        struct,
        ISoftVector2<T, Num>
    where Num : INumber<Num>
{
    public Num X { get; set; }
    public Num Y { get; set; }
    public T One { get; }
    public T Zero { get; }

    public static abstract T New(Num value);
    public static abstract T New(Num x, Num y);
    public static virtual void Abs(in T value, out T result)
    {
        result = T.New(Num.Abs(value.X), Num.Abs(value.Y));
    }

    public static virtual void Add(in T left, Num scalar, out T result)
    {
        result = T.New(
            left.X + scalar,
            left.Y + scalar
        );
    }
    public static virtual void Add(in T left, in T right, out T result)
    {
        result = T.New(
            left.X + right.X,
            left.Y + right.Y
        );
    }

    public static virtual void Clamp(in T value, in T min, in T max, out T result)
    {
        result = T.New(
            Num.MaxMagnitude(Num.MinMagnitude(value.X,max.X), min.X),
            Num.MaxMagnitude(Num.MinMagnitude(value.Y,max.Y), min.Y)
        );
    }
    public static abstract Num Distance(in T value);
    public static virtual Num DistanceSquared(in T value)
    {
        return value.X * value.X + value.Y * value.Y;
    }
    public static virtual void Divide(Num scalar, in T value, out T result)
    {
        result = T.New(
            scalar / value.X,
            scalar / value.Y
        );
    }
    public static virtual void Divide(in T value, Num scalar, out T result)
    {
        result = T.New(
            value.X / scalar,
            value.Y / scalar
        );
    }
    public static virtual void Divide(in T left, in T right, out T result)
    {
        result = T.New(
            left.X / right.X,
            left.Y / right.Y
        );
    }
    public static virtual Num Dot(in T left, in T right)
    {
        return left.X * right.X + left.Y * right.Y;
    }
    public static virtual void Lerp(in T value1, in T value2, Num amount, out T result)
    {
        T.Subtract(value2, value1, out var sub);
        T.Multiply(sub, amount, out var mul);
        T.Add(value1, mul, out result);
    }
    public static virtual void Multiply(in T value, Num scalar, out T result)
    {
        result = T.New(
            value.X * scalar,
            value.Y * scalar
        );
    }
    public static virtual void Multiply(in T left, in T right, out T result)
    {
        result = T.New(
            left.X * right.X,
            left.Y * right.Y
        );
    }
    public static virtual void Negate(in T value, out T result)
    {
        result = T.New(
            -value.X,
            -value.Y
        );
    }
    public static virtual void Normalize(in T value, out T result)
    {
        var x = value.X;
        var y = value.Y;
        result = T.New(
            x < -Num.One ? -Num.One : x > Num.One ? Num.One : x, 
            x < -Num.One ? -Num.One : x > Num.One ? Num.One : y 
        );
    }
    public static virtual void Reflect(in T vector, in T normal, out T result)
    {
        Num dot = T.Dot(vector,normal);
        result = T.New(
            vector.X - (Num.One + Num.One) * dot * normal.X,
            vector.Y - (Num.One + Num.One) * dot * normal.Y
        );
    }
    public static abstract void SquareRoot(in T value, out T result);
    
    public static virtual void Subtract(in T left, Num scalar, out T result)
    {
        result = T.New(
            left.X - scalar,
            left.Y - scalar
        );
    }
    public static virtual void Subtract(Num scalar, in T left, out T result)
    {
        result = T.New(
            scalar - left.X,
            scalar - left.Y
        );
    }
    public static virtual void Subtract(in T left, in T right, out T result)
    {
        result = T.New(
            left.X - right.X,
            left.Y - right.Y
        );
    }

    public static virtual void Transform(in T vector, in T transform, out T result)
    {
        T.Add(vector,transform, out result);
    }
    // public static virtual void TransformNormal(in T left, in T right, out T result);
}
