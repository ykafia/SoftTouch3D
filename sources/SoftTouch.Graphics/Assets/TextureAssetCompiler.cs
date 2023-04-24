using SoftTouch.Core.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using MemoryPack;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.Assets;

public class TextureAssetCompiler : AssetCompiler<TextureAsset, ValueTuple<TextureDescriptor, byte[]>>
{
    public override byte[] Compile(TextureAsset asset)
    {
        (TextureDescriptor descriptor, byte[] data) data = new(new TextureDescriptor(), new byte[asset.Size.X * asset.Size.Y * asset.Size.Z]) ;
        var manager = AssetManager.GetOrCreate();
        var realPath = manager.ResourceFileSystem.ConvertPathToInternal(asset.Path);
        Image.Load<Rgba32>(realPath).CopyPixelDataTo(data.data.AsSpan());
        data.descriptor = new()
        {
            Size = new(asset.Size.X, asset.Size.Y, asset.Size.Z),
            SampleCount = 1,
            MipLevelCount = 1,
            Usage = TextureUsage.CopyDst | TextureUsage.CopySrc | TextureUsage.TextureBinding,
            Format = TextureFormat.Rgba8Uint,
            Dimension = TextureDimension.TextureDimension2D
        };
        return Serialize(in data);
    }
}
