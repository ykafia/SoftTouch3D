using WGPU.NET;
using Buffer = WGPU.NET.Buffer;

namespace SoftTouch.Graphics;


public class IndexBufferBinding
{
    public Buffer IndexBuffer { get; private set; }
    public int Size { get; private set; }
    public long Count { get; private set; }
}