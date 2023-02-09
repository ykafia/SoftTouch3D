using System.Collections.Generic;
using WGPU.NET;

namespace SoftTouch.Graphics;


public readonly struct MeshData
{
    public uint[]? Indices { get; init; }
    public byte[] Vertices { get; init; }
    public ulong Stride { get; init; }
    public ulong Offset { get; init; }
    public Wgpu.PrimitiveTopology Topology { get; init; }
    public VertexBufferLayout Layout { get; init; }
    public ulong VertexCount { get; init; }

    public bool IsNonIndexed => Indices is null;


}
