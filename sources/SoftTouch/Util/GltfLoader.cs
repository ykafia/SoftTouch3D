using System;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;
using SoftTouch.Assets;
using SoftTouch.Graphics.WGPU;
using WGPU.NET;
using Zio;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SoftTouch.Util;

public static class GltfLoader
{
    public static void LoadGltf(UPath path, IFileSystem fs, WGPUGraphics graphics, out ModelAsset model)
    {
        model = new ModelAsset();


        var gltf = ModelRoot.Load(fs.ConvertPathToInternal(path));
        // var image = SixLabors.ImageSharp.Image.Load<Rgba32>(gltf.LogicalTextures.First().PrimaryImage.Content.Content.ToArray());
        // var imageSize = new Wgpu.Extent3D
        // {
        //     width = (uint)image.Width,
        //     height = (uint)image.Height,
        //     depthOrArrayLayers = 1
        // };

        // // Instantiate in gpu
        // var imageTexture = graphics.Device.CreateTexture("Image",
        //     usage: Wgpu.TextureUsage.TextureBinding | Wgpu.TextureUsage.CopyDst,
        //     dimension: Wgpu.TextureDimension.TwoDimensions,
        //     size: imageSize,
        //     format: Wgpu.TextureFormat.RGBA8Unorm,
        //     mipLevelCount: 1,
        //     sampleCount: 1
        // );

        // {
        //     // Send data to gpu
        //     Span<Rgba32> pixels = new Rgba32[image.Width * image.Height];

        //     image.CopyPixelDataTo(pixels);

        //     graphics.Device.GetQueue().WriteTexture<Rgba32>(
        //         destination: new ImageCopyTexture
        //         {
        //             Aspect = Wgpu.TextureAspect.All,
        //             MipLevel = 0,
        //             Origin = default,
        //             Texture = imageTexture
        //         },
        //         data: pixels,
        //         dataLayout: new Wgpu.TextureDataLayout
        //         {
        //             bytesPerRow = (uint)(sizeof(byte) * 4 * image.Width),
        //             offset = 0,
        //             rowsPerImage = (uint)image.Height
        //         },
        //         writeSize: imageSize
        //     );
        // }

        // // Instantiate sampler
        // var imageSampler = graphics.Device.CreateSampler("ImageSampler",
        //     addressModeU: Wgpu.AddressMode.ClampToEdge,
        //     addressModeV: Wgpu.AddressMode.ClampToEdge,
        //     addressModeW: default,

        //     magFilter: Wgpu.FilterMode.Linear,
        //     minFilter: Wgpu.FilterMode.Linear,
        //     mipmapFilter: Wgpu.MipmapFilterMode.Linear,

        //     lodMinClamp: 0,
        //     lodMaxClamp: 1,
        //     compare: default,

        //     maxAnisotropy: 1
        // );

        foreach (var prim in gltf.LogicalMeshes[0].Primitives)
        {

            ulong stride = (ulong)prim.VertexAccessors.Values.Select(x => x.Format.ByteSize).Sum();
            ulong offset = 0;
            model.Layouts.Add(new()
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
            });

            var p = new Assets.MeshPrimitive
            {
                Topology = prim.DrawPrimitiveType.Into(),
                Indices = prim.GetIndices()?.ToArray(),
                VertexCount = (ulong)prim.GetVertices("POSITION").AsVector3Array().Count
            };
            var count = (int)p.VertexCount;
            var buffer = new List<byte>(count * (int)stride);
            p.LayoutOrder = prim.VertexAccessors.Keys.ToList();
            for (int i = 0; i < count; i++)
            {
                foreach (var accessor in prim.VertexAccessors)
                {
                    buffer.AddRange(accessor.Value.TryGetVertexBytes(i));
                }
            }
            model.Meshes.Add(new MeshDraw(p, graphics));
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