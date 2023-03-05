using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class Queue : GraphicsBaseObject<Silk.NET.WebGPU.Queue>
{
    internal unsafe Queue(Silk.NET.WebGPU.Queue* handle) : base(handle) { }

    public void Submit(CommandBuffer[] commandbuffer)
    {
        unsafe
        {
            var buffer = stackalloc Silk.NET.WebGPU.CommandBuffer*[commandbuffer.Length];
            for (int i = 0; i < commandbuffer.Length; i++)
                buffer[i] = commandbuffer[i].Handle;
            Api.QueueSubmit(Handle, (uint)commandbuffer.Length, buffer);


        }
    }
    public void WriteBuffer<T>(Buffer buffer, uint offset, uint size, Span<T> data)
        where T : unmanaged
    {
        unsafe
        {
            fixed(T* dataPtr = data) 
                Api.QueueWriteBuffer(Handle, buffer.Handle, offset, dataPtr, size);
        }
    }
    public void WriteTexture<T>(Texture texture, uint offset, uint size, Span<T> data)
        where T : unmanaged
    {
        unsafe
        {
            fixed (T* dataPtr = data)
                Api.QueueWriteTexture(Handle, texture.Handle, offset, dataPtr, size);
        }
    }

    public override void Dispose()
    {
        unsafe
        {
            Api.Queue
            //Graphics.Disposal.Dispose(Handle);
        }
    }
}
