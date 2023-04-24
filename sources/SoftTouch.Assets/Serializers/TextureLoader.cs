using MemoryPack;
using SoftTouch.Assets.Assets.Compilers;
using SoftTouch.Core.Assets;
using SoftTouch.Graphics.WGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using TextureUsage = Silk.NET.WebGPU.TextureUsage;
using ImageCopyTexture = Silk.NET.WebGPU.ImageCopyTexture;

namespace SoftTouch.Assets.Serializers;

public class TextureSerializer : ContentSerializer<Texture>
{
    public override Texture Load(UPath path)
    {
        var gfx = GraphicsState.GetOrCreate();
        Content.Deserialize<TextureData>(path, out var data);
        data.Descriptor = data.Descriptor with { Usage = TextureUsage.CopyDst | TextureUsage.TextureBinding };

        var texture = gfx.Device.CreateTexture(
            path.GetNameWithoutExtension() ?? throw new Exception($"Path {path} has no name"),
            data.Descriptor,
            data.Bytes.AsSpan()
        );
        return texture;
    }

    public override void Save(Texture data)
    {
        throw new NotImplementedException();
    }
}
