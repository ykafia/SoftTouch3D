using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryPack;
using WGPU.NET;

namespace SoftTouch.Graphics.Serialization;

public class TextureSerializer : MemoryPackFormatter<Texture>
{
    public override void Deserialize(ref MemoryPackReader reader, scoped ref Texture? value)
    {
        // var label = reader.ReadValue<string>();
        // var format = reader.ReadValue<Wgpu.TextureFormat>();
        // var size = reader.ReadValue<Wgpu.Extent3D>();
        // var dimension = reader.ReadValue<Wgpu.TextureDimension>();
        // var mipCount = reader.ReadValue<uint>();

    }

    public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, scoped ref Texture? value)
    {

        if (value is null)
            throw new ArgumentNullException("value");
        // writer.WriteValue(value.Label);
        // writer.WriteValue(value.Format);
        // writer.WriteValue(value.Size);
        // writer.WriteValue(value.Dimension);
        // writer.WriteValue(value.MipLevelCount);
        // writer.WriteValue(value.Usage);
        //writer.WriteSpan<byte>()
        //CommandEncoder ce;
        //ce.CopyTexureToBuffer()

        
        throw new NotImplementedException();
    }
}
