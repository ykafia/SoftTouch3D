using MemoryPack;
using SoftTouch.Core.Assets;
using SoftTouch.Graphics.WGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using TextureDescriptor = Silk.NET.WebGPU.TextureDescriptor;

namespace SoftTouch.Assets.Serializers;

public class TextureSerializer : ContentSerializer<Texture>
{
    public override Texture Load(UPath path)
    {
        if (Texture.Textures.ContainsKey((string)path))
            return Texture.Textures[(string)path];
        var gfx = GraphicsState.GetOrCreate();
        Content.Deserialize<(TextureDescriptor desc, byte[] data)>(path, out var data);

        var texture = gfx.Device.CreateTexture(
            path.GetNameWithoutExtension() ?? throw new Exception($"Path {path} has no name"),
            data.desc,
            data.data.AsSpan()
        );
        return texture;
    }

    public override void Save(Texture data)
    {
        throw new NotImplementedException();
    }
}
