using Silk.NET.Maths;
using System.Runtime.Serialization;
using SoftTouch.ECS;
using System.Text;

namespace SoftTouch.Components;




[DataContract]
public struct Transform
{
    [DataMember(Order = 0)]
    public Vector3D<float> Position = Vector3D<float>.Zero;
    [DataMember(Order = 1)]
    public Quaternion<float> Rotation = Quaternion<float>.Identity;
    [DataMember(Order = 2)]
    public Vector3D<float> Scale = Vector3D<float>.One;

    public Transform(){}
    
    public void ToMatrix(out Matrix4X4<float> result)
    {
        result = Matrix4X4.CreateTranslation(Position);
        result = Matrix4X4.Transform(result,Rotation);
    }
    public override string ToString()
    {
        return 
            new StringBuilder()
            .Append("T<")
            .Append(Position.X.ToString("0.00"))
            .Append(", ")
            .Append(Position.Y.ToString("0.00"))
            .Append(", ")
            .Append(Position.Z.ToString("0.00"))
            .AppendLine(">")
            .Append("S<")
            .Append(Scale.X.ToString("0.00"))
            .Append(", ")
            .Append(Scale.Y.ToString("0.00"))
            .Append(", ")
            .Append(Scale.Z.ToString("0.00"))
            .AppendLine(">")
            .Append("R<")
            .Append(Rotation.X.ToString("0.00"))
            .Append(", ")
            .Append(Rotation.Y.ToString("0.00"))
            .Append(", ")
            .Append(Rotation.Z.ToString("0.00"))
            .Append(", ")
            .Append(Rotation.W.ToString("0.00"))
            .AppendLine(">")
            .ToString();
    }
}

public struct GlobalTransform
{
    public Vector3D<float> Position;
    public Quaternion<float> Rotation;
    public Vector3D<float> Scale;

    public void ToMatrix(out Matrix4X4<float> result)
    {
        result = 
            Matrix4X4<float>.Identity 
            * Matrix4X4.CreateFromQuaternion(Rotation) 
            * Matrix4X4.CreateScale(Scale) 
            * Matrix4X4.CreateTranslation(Position);
    }
}

//public readonly struct TransformBundle : IBundle
//{
//    public readonly Transform Transform;
//    public readonly Transform GTransform;

//    public TransformBundle(Transform transform, Transform gTransform)
//    {
//        Transform = transform;
//        GTransform = gTransform;
//    }

//    public void AddBundle(EntityBuilder b)
//    {
//        //b.With(Transform);
//        //b.With(GTransform);
//    }
//}