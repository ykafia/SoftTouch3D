using WGPU.NET;
using MemoryPack;

namespace SoftTouch.WGPU.Serializers;


public class TextureFormatSerializers : MemoryPackFormatter<Texture>
{
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Texture? value)
    {
        
        throw new NotImplementedException();
    }

    public override void Deserialize(ref MemoryPackReader reader, scoped ref Texture? value)
    {
        throw new NotImplementedException();
    }
    
}