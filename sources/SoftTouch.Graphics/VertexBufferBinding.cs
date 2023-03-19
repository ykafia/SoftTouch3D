

using Silk.NET.WebGPU;
using SoftTouch.Graphics.WGPU;

namespace SoftTouch.Graphics;


public class VertexBufferBinding
{
    public string Label { get; }
    public SoftTouch.Graphics.WGPU.Buffer VertexBuffer { get; private set; }
    public ulong Offset { get; private set; }
    public ulong Stride { get; private set; }
    public ulong Count { get; private set; }
    public VertexBufferLayout Layout { get; private set; }

    public VertexBufferBinding(string label, bool mappedAtCreation, ulong offset, ulong stride, ulong count, VertexBufferLayout layout, byte[] bufferData)
    {
        Label = label;
        // VertexBuffer = GraphicsState.GetOrCreate().Device.CreateBuffer(
        //     "VertexBuffer",
        //     mappedAtCreation, 
        //     count * stride, 
        //     Wgpu.BufferUsage.Vertex
        // );
        // Offset = offset;
        // Stride = stride;
        // Count = count;
        // Layout = layout;
        // {
        //     // Fill the vertex buffer
        //     Span<byte> mapped = VertexBuffer.GetMappedRange<byte>(0, bufferData.Length);

        //     bufferData.CopyTo(mapped);

        //     VertexBuffer.Unmap();
        // }
    }
}