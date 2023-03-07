using System.Text;
using Silk.NET.WebGPU;

namespace SoftTouch.Graphics.SilkWrappers;

public readonly struct Queue : IGraphicsObject
{
    public unsafe Silk.NET.WebGPU.Queue* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;

    internal unsafe Queue(Silk.NET.WebGPU.Queue* handle)
    {
        Handle = handle;
    }
    public unsafe static implicit operator Silk.NET.WebGPU.Queue*(Queue a) => a.Handle;

    public void SetLabel(string label)
    {
        unsafe
        {
            var bytes = Encoding.UTF8.GetBytes(label);
            fixed (byte* ptr = bytes)
                Api.QueueSetLabel(Handle, ptr);
        }
    }

    public void OnSubmittedWorkDone<T>(Silk.NET.WebGPU.PfnQueueWorkDoneCallback callback, T[] data) 
        where T : unmanaged
    {
        unsafe
        {
            fixed (T* pdata = data)
                Api.QueueOnSubmittedWorkDone(Handle, callback, pdata);
        }
    }

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
    public void WriteTexture<T>(Silk.NET.WebGPU.ImageCopyTexture texture, nuint dataSize, Span<T> data, Silk.NET.WebGPU.TextureDataLayout dataLayout, Silk.NET.WebGPU.Extent3D size)
        where T : unmanaged
    {
        unsafe
        {
            fixed (T* dataPtr = data)
                Api.QueueWriteTexture(Handle, &texture, dataPtr, dataSize, &dataLayout, &size);
        }
    }

    public void Dispose()
    {
        unsafe
        {
            //Graphics.Disposal.Dispose(Handle);
        }
    }
}
