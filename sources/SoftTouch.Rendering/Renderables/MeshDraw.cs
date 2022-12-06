using System;
using SoftTouch.Graphics.WGPU;
using WGPU.NET;

namespace SoftTouch.Rendering.Renderables;

public class MeshDraw
{
    public WGPU.NET.Buffer VertexBuffer {get;}
    public WGPU.NET.Buffer IndexBuffer {get;}
    
    public MeshDraw(MeshPrimitive primitive, WGPUGraphics graphics)
    {
        VertexBuffer = graphics.Device.CreateBuffer("VertexBuffer", true, (ulong)primitive.Vertices.Length, Wgpu.BufferUsage.Vertex);
        {
            // Fill the vertex buffer
            Span<byte> mapped = VertexBuffer.GetMappedRange<byte>(0, primitive.Vertices.Length);

            primitive.Vertices.CopyTo(mapped);

            VertexBuffer.Unmap();
        }
        IndexBuffer = graphics.Device.CreateBuffer("IndexBuffer", true, (ulong)(primitive.Indices.Length * sizeof(uint)), Wgpu.BufferUsage.Index);
        {
            // Fill the index buffer
            Span<uint> mapped = IndexBuffer.GetMappedRange<uint>(0, primitive.Indices.Length);

            primitive.Indices.CopyTo(mapped);

            IndexBuffer.Unmap();
        }
    }
}
