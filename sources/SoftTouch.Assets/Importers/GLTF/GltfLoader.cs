using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SoftTouch.Assets;
using SoftTouch.Graphics.WebGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SoftTouch.Rendering.Renderables;
using SoftTouch.Graphics;

namespace SoftTouch.Assets.Importers.GLTF;

public static partial class MeshImporter
{
    public static void LoadGltf(UPath path, IFileSystem fs, out ModelAsset model)
    {
        model = new ModelAsset();


        var gltf = ModelRoot.Load(fs.ConvertPathToInternal(path));
        
        foreach (var prim in gltf.LogicalMeshes[0].Primitives)
        {

            ulong stride = (ulong)prim.VertexAccessors.Values.Select(x => x.Format.ByteSize).Sum();
            ulong offset = 0;
            var layout = new VertexBufferLayout()
            {
                ArrayStride = stride,
                Attributes = prim.VertexAccessors.Select(
                    (x, i) =>
                    {
                        offset += (ulong)x.Value.Format.ByteSize;
                        return new Wgpu.VertexAttribute()
                        {
                            format = x.Value.Format.Into(),
                            offset = offset,
                            shaderLocation = (uint)i
                        };
                    }
                ).ToArray()
            };

            var p = new MeshData()
            {
                Topology = prim.DrawPrimitiveType.Into(),
                Indices = prim.GetIndices()?.ToArray(),
                VertexCount = (ulong)prim.GetVertices("POSITION").AsVector3Array().Count,
                Layout = layout,
                Stride = stride,
                Offset = offset 
            };
            
            var count = (int)p.VertexCount;
            var buffer = new List<byte>(count * (int)stride);
            for (int i = 0; i < count; i++)
            {
                foreach (var accessor in prim.VertexAccessors)
                {
                    buffer.AddRange(accessor.Value.TryGetVertexBytes(i));
                }
            }
            // model.Meshes.Add(new MeshDraw(p, graphics));
        }
    }


    public static Wgpu.VertexFormat Into(this AttributeFormat format)
    {
        return format switch
        {
            { Dimensions: DimensionType.VEC2, Encoding: EncodingType.UNSIGNED_BYTE } => Wgpu.VertexFormat.Uint8x2,
            { Dimensions: DimensionType.VEC4, Encoding: EncodingType.UNSIGNED_BYTE } => Wgpu.VertexFormat.Uint8x4,
            { Dimensions: DimensionType.VEC2, Encoding: EncodingType.UNSIGNED_SHORT } => Wgpu.VertexFormat.Uint16x2,
            { Dimensions: DimensionType.VEC4, Encoding: EncodingType.UNSIGNED_SHORT } => Wgpu.VertexFormat.Uint16x4,
            { Dimensions: DimensionType.SCALAR, Encoding: EncodingType.UNSIGNED_INT } => Wgpu.VertexFormat.Uint32,
            { Dimensions: DimensionType.VEC2, Encoding: EncodingType.UNSIGNED_INT } => Wgpu.VertexFormat.Uint32x2,
            { Dimensions: DimensionType.VEC3, Encoding: EncodingType.UNSIGNED_INT } => Wgpu.VertexFormat.Uint32x3,
            { Dimensions: DimensionType.VEC4, Encoding: EncodingType.UNSIGNED_INT } => Wgpu.VertexFormat.Uint32x4,
            { Dimensions: DimensionType.VEC2, Encoding: EncodingType.BYTE } => Wgpu.VertexFormat.Sint8x2,
            { Dimensions: DimensionType.VEC4, Encoding: EncodingType.BYTE } => Wgpu.VertexFormat.Sint8x4,
            { Dimensions: DimensionType.VEC2, Encoding: EncodingType.SHORT } => Wgpu.VertexFormat.Sint16x2,
            { Dimensions: DimensionType.VEC4, Encoding: EncodingType.SHORT } => Wgpu.VertexFormat.Sint16x4,
            { Dimensions: DimensionType.SCALAR, Encoding: EncodingType.FLOAT } => Wgpu.VertexFormat.Float32,
            { Dimensions: DimensionType.VEC2, Encoding: EncodingType.FLOAT } => Wgpu.VertexFormat.Float32x2,
            { Dimensions: DimensionType.VEC3, Encoding: EncodingType.FLOAT } => Wgpu.VertexFormat.Float32x3,
            { Dimensions: DimensionType.VEC4, Encoding: EncodingType.FLOAT } => Wgpu.VertexFormat.Float32x4,
            _ => throw new NotImplementedException()
        };
    }
    public static Wgpu.PrimitiveTopology Into(this PrimitiveType primitiveType)
    {
        return primitiveType switch
        {
            PrimitiveType.LINES => Wgpu.PrimitiveTopology.LineList,
            PrimitiveType.LINE_STRIP => Wgpu.PrimitiveTopology.LineStrip,
            PrimitiveType.TRIANGLES => Wgpu.PrimitiveTopology.TriangleList,
            PrimitiveType.TRIANGLE_STRIP => Wgpu.PrimitiveTopology.TriangleStrip,
            PrimitiveType.POINTS => Wgpu.PrimitiveTopology.PointList,
            _ => throw new NotImplementedException()
        };
    }
}