using WGPU.NET;
using Buffer = WGPU.NET.Buffer;

namespace SoftTouch.Graphics;


public class VertexBufferBinding
{
    public Buffer VertexBuffer { get; private set; }
    public int Offset { get; private set; }
    public int Stride { get; private set; }
    public long Count { get; private set; }
    public VertexBufferLayout Layout { get; private set; }
}