using static WGPU.NET.Wgpu;
using MemoryPack;

namespace SoftTouch.WGPU.Serializers;


public class TextureFormatSerializers : MemoryPackFormatter<TextureFormat>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref TextureFormat value)
    {
        throw new NotImplementedException();
    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref TextureFormat value)
    {
        throw new NotImplementedException();
    }
}