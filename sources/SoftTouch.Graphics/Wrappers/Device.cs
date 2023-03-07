using Silk.NET.SDL;
using Silk.NET.WebGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SoftTouch.Graphics.SilkWrappers;

public readonly struct Device : IGraphicsObject
{


    public unsafe Silk.NET.WebGPU.Device* Handle { get; init; }

    public GraphicsState Graphics => GraphicsState.GetOrCreate();

    public WebGPU Api => Graphics.Api;

    internal unsafe Device(Silk.NET.WebGPU.Device* handle)
    {
        Handle = handle;
    }

    public unsafe static implicit operator Silk.NET.WebGPU.Device*(Device d) => d.Handle;

    public Buffer CreateBuffer(BufferDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBuffer(Handle, &descriptor));
        }
    }
    public Texture CreateTexture(TextureDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateTexture(Handle, &descriptor));
        }
    }
    public Sampler CreateSampler(SamplerDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateSampler(Handle, &descriptor));
        }
    }
    public BindGroup CreateBindGroup(BindGroupDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBindGroup(Handle, &descriptor));
        }
    }
    public BindGroupLayout CreateBindGroupLayout(BindGroupLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBindGroupLayout(Handle, &descriptor));
        }
    }
    public CommandEncoder CreateCommandEncoder(CommandEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateCommandEncoder(Handle, &descriptor));
        }
    }
    public ComputePipeline CreateComputePipeline(ComputePipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateComputePipeline(Handle, &descriptor));
        }
    }
    public QuerySet CreateQuerySet(QuerySetDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateQuerySet(Handle, &descriptor));
        }
    }
    public void CreateComputePipelineAsync<T0>(ComputePipelineDescriptor descriptor, PfnCreateComputePipelineAsyncCallback callback, ref T0 userData)
        where T0 : unmanaged
    {
        unsafe
        {
            Api.DeviceCreateComputePipelineAsync(Handle, &descriptor, callback, ref userData);
        }
    }
    public PipelineLayout CreatePipelineLayout(PipelineLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreatePipelineLayout(Handle, &descriptor));
        }
    }
    public RenderBundleEncoder CreateRenderBundleEncoder(RenderBundleEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateRenderBundleEncoder(Handle, &descriptor));
        }
    }

    // TODO : This shouldn't exist per the doc : https://www.w3.org/TR/webgpu/
    //public RenderBundle CreateRenderBundle(RenderBundleDescriptor descriptor)
    //{
    //    unsafe
    //    {
    //        return new(Api.CreateRenderBundle(Handle, &descriptor));
    //    }
    //}

    public RenderPipeline CreateRenderPipeline(RenderPipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateRenderPipeline(Handle, &descriptor));
        }
    }
    public void CreateRenderPipelineAsync(RenderPipelineDescriptor descriptor, PfnCreateRenderPipelineAsyncCallback callback, nint userData)
    {
        unsafe
        {
            Api.DeviceCreateRenderPipelineAsync(Handle, &descriptor, callback, (void*)userData);
        }
    }
    public ShaderModule CreateShaderModule(ShaderModuleDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateShaderModule(Handle, &descriptor));
        }
    }

    public SwapChain CreateSwapChain(SwapChainDescriptor descriptor, Surface surface)
    {
        unsafe
        {
            return new(Api.DeviceCreateSwapChain(Handle, surface.Handle, &descriptor));
        }
    }

    public Queue GetQueue()
    {
        unsafe
        {
            return new(Api.DeviceGetQueue(Handle));
        }
    }

    public bool HasFeature(FeatureName feature)
    {
        unsafe
        {
            return Api.DeviceHasFeature(Handle, feature);
        }
    }

    public bool PopErrorScope<T>(PfnErrorCallback callback, T[] data)
        where T : unmanaged
    {
        unsafe
        {
            fixed(T* ptr = data)
                return Api.DevicePopErrorScope(Handle, callback,ptr);
        }
    }
    public void PushErrorScope<T>(ErrorFilter filter)
        where T : unmanaged
    {
        unsafe
        {
            Api.DevicePushErrorScope(Handle,filter);
        }
    }
    public void SetDeviceLostCallback<T>(PfnDeviceLostCallback callback, T[] data)
        where T : unmanaged
    {
        unsafe
        {
            fixed (T* ptr = data)
                Api.DeviceSetDeviceLostCallback(Handle, callback, ptr);
        }
    }

    public void SetLabel(string label)
    {
        unsafe
        {
            var bytes = Encoding.UTF8.GetBytes(label);
            fixed (byte* ptr = bytes)
                Api.DeviceSetLabel(Handle, ptr);
        }
    }



    public void Dispose()
    {
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}
