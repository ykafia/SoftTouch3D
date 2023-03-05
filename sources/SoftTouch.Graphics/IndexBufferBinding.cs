using System.Runtime.InteropServices;
using WGPU.NET;
using Buffer = WGPU.NET.Buffer;

namespace SoftTouch.Graphics;


public class IndexBufferBinding
{
    public string Label { get; }

    public Buffer IndexBuffer { get; private set; }
    public int Size { get; private set; }
    public long Count { get; private set; }

    public IndexBufferBinding(string label, Device device, bool mappedAtCreation, uint[] indices)
    {
        Label = label;
        IndexBuffer = device.CreateBuffer(
            label,
            mappedAtCreation,
            (ulong)indices.Length * (ulong)Marshal.SizeOf(typeof(uint)),
            Wgpu.BufferUsage.Vertex
        );
        
        Count = indices.Length;
        {
            // Fill the vertex buffer
            Span<uint> mapped = IndexBuffer.GetMappedRange<uint>(0, indices.Length);

            indices.CopyTo(mapped);

            IndexBuffer.Unmap();
        }
    }
}