using Silk.NET.Core.Native;
using SoftTouch.Graphics.WGPU;
using Buffer = SoftTouch.Graphics.WGPU.Buffer;

namespace SoftTouch.Graphics;


public readonly struct IndexBufferBinding
{
    public string Label { get; }
    public Buffer IndexBuffer { get; init;}
    public nuint Size { get; init;}

    public IndexBufferBinding(string label, in Silk.NET.WebGPU.BufferDescriptor descriptor, uint[] indices)
    {
        Label = label;
        Size = (nuint)descriptor.Size;
        var desc = new Silk.NET.WebGPU.BufferDescriptor();
        
        Span<byte> lbl = stackalloc byte[label.Length];
        SilkMarshal.StringIntoSpan(label,null);
        unsafe
        {
            fixed(byte* bytes = lbl)
                desc.Label = bytes;
        }
        desc.Size = Size;
        desc.Usage = Silk.NET.WebGPU.BufferUsage.Index;
        


        var gfx = GraphicsState.GetOrCreate();
        var device = gfx.Device;
        IndexBuffer = device.CreateBuffer(
            label,
            in descriptor
        );
        device.GetQueue().WriteBuffer(IndexBuffer,0,Size,indices.AsSpan());
    }
}