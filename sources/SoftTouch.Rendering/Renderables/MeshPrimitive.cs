using System.Collections.Generic;
using WGPU.NET;

namespace SoftTouch.Rendering.Renderables;


public struct MeshPrimitive
{
    public uint[]? Indices;
    public byte[] Vertices;
    public Wgpu.PrimitiveTopology Topology;
    public List<string> LayoutOrder;
    public ulong VertexCount;

    public bool IsNonIndexed => Indices is null;
}
