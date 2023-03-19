using MemoryPack;
using SoftTouch.Graphics;
using SoftTouch.Graphics.WGPU;

namespace SoftTouch.WGPU.Serialization;


public class TextureFormatSerializers : MemoryPackFormatter<Texture>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Texture value)
    {
        throw new NotImplementedException();
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Texture value)
    {
        throw new NotImplementedException();
    }
}