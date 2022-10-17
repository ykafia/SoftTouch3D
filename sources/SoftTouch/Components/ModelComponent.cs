using WGPU.NET;
using System.Linq;
using System.Collections.Generic;

namespace SoftTouch.Components;


public struct MeshPrimitive
{
    public uint[]? Indices;
    public byte[] Vertices;
    public Wgpu.PrimitiveTopology Topology;
    public List<string> LayoutOrder;

    public bool IsNonIndexed => Indices is null;
}


public readonly struct ModelComponent
{
    public readonly List<MeshPrimitive> Primitives = new();
    public readonly List<VertexBufferLayout> Layouts = new();

    public ModelComponent()
    {
    }

    
}