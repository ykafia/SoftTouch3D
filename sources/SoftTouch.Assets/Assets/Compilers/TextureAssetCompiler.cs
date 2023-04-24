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

namespace SoftTouch.Assets.Assets.Compilers;

[MemoryPackable]
public partial struct TextureData
{
    public byte[] Bytes { get; set; }
    public TextureDescriptor Descriptor { get; set; }
}

public class TextureAssetCompiler : AssetCompiler<TextureAsset,TextureData>
{
    public override byte[] Compile(TextureAsset asset)
    {
        var data = new TextureData();
        var manager = AssetManager.GetOrCreate();
        var realPath = manager.ResourceFileSystem.ConvertPathToInternal(asset.Path);
        Image.Load<Rgba32>(realPath).CopyPixelDataTo(data.Bytes.AsSpan());
        data.Descriptor = new()
        {
            Format = Silk.NET.WebGPU.TextureFormat.Rgba8Uint
        };
        return Serialize(in data);
    }
}
