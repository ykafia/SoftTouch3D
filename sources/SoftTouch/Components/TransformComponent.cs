using System.Numerics;
using ECSharp;
using MessagePack;
using MessagePack.Formatters;

namespace SoftTouch.Components;




[MessagePackObject]
public struct Transform
{
    [Key(0)]
    public Vector3 Position = Vector3.Zero;
    [Key(1)]
    public Quaternion Rotation = Quaternion.Identity;
    [Key(2)]
    public Vector3 Scale = Vector3.One;

    public Transform(){}
    
    public void ToMatrix(out Matrix4x4 result)
    {
        result = Matrix4x4.CreateScale(Scale);
        result.Translation = Position;
        result *= Matrix4x4.CreateFromQuaternion(Rotation);
    }
}

public struct GlobalTransform
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;

    public void ToMatrix(out Matrix4x4 result)
    {
        result = Matrix4x4.CreateScale(Scale);
        result.Translation = Position;
        result *= Matrix4x4.CreateFromQuaternion(Rotation);
    }
}

public readonly struct TransformBundle : IBundle
{
    public readonly Transform Transform;
    public readonly Transform GTransform;

    public TransformBundle(Transform transform, Transform gTransform)
    {
        Transform = transform;
        GTransform = gTransform;
    }

    public void AddBundle(EntityBuilder b)
    {
        b.With(Transform);
        b.With(GTransform);
    }
}