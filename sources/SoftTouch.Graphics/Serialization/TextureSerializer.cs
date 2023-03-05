using WGPU.NET;
using MemoryPack;
using SoftTouch.Graphics;

namespace SoftTouch.WGPU.Serialization;


public class TextureFormatSerializers : MemoryPackFormatter<Texture>
{
    TrivaxyGraphicsState gfx => TrivaxyGraphicsState.GetOrCreate();
    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Texture? value)
    {
        throw new NotImplementedException();
    }

    public override void Deserialize(ref MemoryPackReader reader, scoped ref Texture? value)
    {
        throw new NotImplementedException();
    }

    public Span<byte> GetData(Texture tex)
    {
        var encoder = gfx.Device.CreateCommandEncoder(null);
        var stagingBuffer = gfx.Device.CreateBuffer(null, false, 0, Wgpu.BufferUsage.MapRead | Wgpu.BufferUsage.CopyDst);
        var copyTex = new ImageCopyTexture() { Texture = tex, MipLevel = tex.MipLevelCount };
        var copyBuf = new ImageCopyBuffer() { Buffer = stagingBuffer};
        encoder.CopyTexureToBuffer(copyTex, copyBuf, tex.Size);
        return stagingBuffer.GetMappedRange<byte>(0, (int)stagingBuffer.SizeInBytes);
    }

}

public static class ExtentExtension
{
    public static ulong GetBufferSize(this Texture e)
    {
        return e.Format switch
        {
            Wgpu.TextureFormat.RGBA8Unorm => 32,
            _ => throw new Exception()
        };
    }
}