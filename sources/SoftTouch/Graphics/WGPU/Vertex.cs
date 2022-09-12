using System.Numerics;

namespace SoftTouch.Graphics.WGPU;
struct Vertex
{
    public Vector3 Position;
    public Vector4 Color;
    public Vector2 UV;

    public Vertex(Vector3 position, Vector4 color, Vector2 uv)
    {
        Position = position;
        Color = color;
        UV = uv;
    }
}

struct UniformBuffer
{
    public Matrix4x4 Transform;
}