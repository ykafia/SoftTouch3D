using MemoryPack;
using SoftTouch.Core.Serialization;
using SoftTouch.Graphics;
using SoftTouch.Graphics.WGPU;

namespace SoftTouch.WGPU.Serialization;


public class TextureFormatSerializers : BinaryFormatter<Texture>
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