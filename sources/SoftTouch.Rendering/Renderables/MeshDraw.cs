using System;
using SoftTouch.Graphics;
using SoftTouch.Graphics.SilkWrappers;
using WGPU.NET;

namespace SoftTouch.Rendering.Renderables;

public class MeshDraw
{
    public VertexBufferBinding VertexBufferBinding {get;}
    public IndexBufferBinding? IndexBufferBinding {get;}
    
    public MeshDraw(in MeshData primitive, GraphicsState graphics)
    {
        //VertexBufferBinding = new(
        //    "VertexBuffer",
        //    graphics.Device,
        //    true,
        //    primitive.Offset,
        //    primitive.Stride,
        //    primitive.VertexCount,
        //    primitive.Layout,
        //    primitive.Vertices
        //);
        
        
        //if(primitive.Indices != null)
        //    IndexBufferBinding = new(
        //        "IndexBuffer",
        //        graphics.Device,
        //        true,
        //        primitive.Indices
        //    );
    }
}
