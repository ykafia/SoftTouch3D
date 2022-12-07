using System;
using SoftTouch.Graphics;
using SoftTouch.Graphics.WebGPU;
using WGPU.NET;

namespace SoftTouch.Rendering.Renderables;

public class MeshDraw
{
    public VertexBufferBinding VertexBuffer {get;}
    public IndexBufferBinding? IndexBuffer {get;}
    
    public MeshDraw(in MeshData primitive, WGPUGraphics graphics)
    {
        VertexBuffer = new(
            "VertexBuffer",
            graphics.Device,
            true,
            primitive.Offset,
            primitive.Stride,
            primitive.VertexCount,
            primitive.Layout,
            primitive.Vertices
        );
        
        
        if(primitive.Indices != null)
            IndexBuffer = new(
                "IndexBuffer",
                graphics.Device,
                true,
                primitive.Indices
            );
    }
}
