using System.Numerics;
using ECSharp;

namespace SoftTouch.Components;

public struct Transform
{
    public Vector3 Position = Vector3.Zero;
    public Quaternion Rotation = Quaternion.Identity;
    public Vector3 Scale = Vector3.One;

    public Transform(){}
}

public struct GlobalTransform
{
    public Vector3 Position;
    public Quaternion Rotation;
    public Vector3 Scale;
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