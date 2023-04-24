using Silk.NET.WebGPU;
namespace SoftTouch.Graphics.WGPU;

public readonly struct Buffer : IGraphicsObject
{
    public static GPUResources<Buffer> Buffers { get; } = new();

    public unsafe Silk.NET.WebGPU.Buffer* Handle { get; init; }
    public GraphicsState Graphics => GraphicsState.GetOrCreate();
    public WebGPU Api => Graphics.Api;



    public uint MapState
    {
        get
        {
            unsafe
            {
                throw new NotImplementedException("Wait for next release of wgpu-native");
                //Api.BufferGetMapState();
            }
        }
    }
    public uint Size
    {
        get
        {
            unsafe
            {
                throw new NotImplementedException("Wait for next release of wgpu-native");
                //Api.BufferGetSize();
            }
        }
    }
    public uint Usage
    {
        get
        {
            unsafe
            {
                throw new NotImplementedException("Wait for next release of wgpu-native");
                //Api.BufferGetUsage();
            }
        }
    }

    internal unsafe Buffer(Silk.NET.WebGPU.Buffer* handle)
    {
        Handle = handle;
    }


    internal unsafe ImageCopyBuffer GetCopyBuffer(Silk.NET.WebGPU.TextureDataLayout layout, uint mipLevel, Silk.NET.WebGPU.Origin3D origin)
    {
        return new ImageCopyBuffer()
        {
            Buffer = Handle,
            Layout = layout,
        };
    }


    //public void CopyToTexture(in Texture texture, ulong offset = 0, uint bytesPerRow = 0, uint rowsPerImage = 0)
    //{
    //    unsafe
    //    {
    //        var copyBuff = new ImageCopyTexture()
    //        {
    //            Buffer = Handle,
    //            Layout = new(null,offset,bytesPerRow,rowsPerImage),
    //        };

    //        Graphics.Device.GetQueue().WriteTexture()
            
    //    }
    //}



    public unsafe static implicit operator Silk.NET.WebGPU.Buffer*(Buffer a) => a.Handle;


    public void Destroy()
    {
        unsafe
        {
        }
    }
    public ReadOnlySpan<byte> GetConstMappedRange(nuint offset, nuint size)
    {
        unsafe
        {
            throw new NotImplementedException("Wait for next release of wgpu-native");
            return new ReadOnlySpan<byte>(Api.BufferGetConstMappedRange(this, offset, size), (int)size);
        }
    }

    public Span<T> GetSlice<T>(Range range)
        where T : unmanaged
    {
        unsafe
        {
            var size = (nuint)(range.End.Value - range.Start.Value);
            return new(Api.BufferGetMappedRange(this, (nuint)range.Start.Value, size), (int)size);
        }
    }

    public Span<T> GetMappedRange<T>(nuint offset, nuint size)
        where T : unmanaged
    {
        unsafe
        {
            return new(Api.BufferGetMappedRange(this, offset, size), (int)size);
        }
    }

    public void MapAsync(MapMode mode, nuint offset, nuint size, PfnBufferMapCallback callback)
    {
        unsafe
        {
            Api.BufferMapAsync(this,mode,offset,size, callback, null);
        }
    }

    public void SetLabel()
    {
        unsafe
        {
            throw new NotImplementedException("Wait for next release of wgpu-native");
            //Api.BufferSetLabel();
        }
    }
    public void Unmap()
    {
        unsafe
        {
            //throw new NotImplementedException("Wait for next release of wgpu-native");
            Api.BufferUnmap(this);
        }
    }



    public void Dispose()
    {
        unsafe
        {
            foreach(var (k,v) in Buffers)
            {
                if(v.Handle == Handle)
                {
                    Buffers.Remove(k);
                    break;
                }
            }
            Api.BufferDestroy(this);
            Graphics.Disposal.Dispose(Handle);
        }
    }
}