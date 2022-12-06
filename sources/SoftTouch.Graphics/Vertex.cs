using Silk.NET.Maths;

namespace SoftTouch.Graphics.WGPU;
struct Vertex
{
    public Vector3D<float> Position;
    public Vector4D<float> Color;
    public Vector2D<float> UV;

    public Vertex(Vector3D<float> position, Vector4D<float> color, Vector2D<float> uv)
    {
        Position = position;
        Color = color;
        UV = uv;
    }
}

struct UniformBuffer
{
    public Matrix4X4<float> Transform;
}