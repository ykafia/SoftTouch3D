using Silk.NET.Core.Native;
using Silk.NET.WebGPU;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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

    public Buffer CreateBuffer([NotNull] string label, in BufferDescriptor descriptor)
    {
        unsafe
        {
            Buffer.Buffers.Add(label, new(Api.DeviceCreateBuffer(Handle, descriptor)));
            return Buffer.Buffers[label];
        }
    }
    public Texture CreateTexture([NotNull] string label, in TextureDescriptor descriptor)
    {
        unsafe
        {
            Texture texture = new(Api.DeviceCreateTexture(Handle, descriptor));
            Texture.Textures.Add(label, texture);
            return texture;
        }
    }
    public Sampler CreateSampler([NotNull] string label, in SamplerDescriptor descriptor)
    {
        unsafe
        {
            Sampler.Samplers.Add(label, new(Api.DeviceCreateSampler(Handle, descriptor)));
            return Sampler.Samplers[label];
        }
    }
    public BindGroup CreateBindGroup(in BindGroupDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBindGroup(Handle, descriptor));
        }
    }
    public BindGroupLayout CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBindGroupLayout(Handle, descriptor));
        }
    }
    public CommandEncoder CreateCommandEncoder(in CommandEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateCommandEncoder(Handle, descriptor));
        }
    }
    public ComputePipeline CreateComputePipeline(in ComputePipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateComputePipeline(Handle, descriptor));
        }
    }
    public QuerySet CreateQuerySet(in QuerySetDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateQuerySet(Handle, descriptor));
        }
    }
    public void CreateComputePipelineAsync<T0>(in ComputePipelineDescriptor descriptor, PfnCreateComputePipelineAsyncCallback callback, ref T0 userData)
        where T0 : unmanaged
    {
        unsafe
        {
            Api.DeviceCreateComputePipelineAsync(Handle, descriptor, callback, ref userData);
        }
    }
    public PipelineLayout CreatePipelineLayout(in PipelineLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreatePipelineLayout(Handle, descriptor));
        }
    }
    public RenderBundleEncoder CreateRenderBundleEncoder(in RenderBundleEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateRenderBundleEncoder(Handle, descriptor));
        }
    }

    // TODO : This shouldn't exist per the doc : https://www.w3.org/TR/webgpu/
    //public RenderBundle CreateRenderBundle(in RenderBundleDescriptor descriptor)
    //{
    //    unsafe
    //    {
    //        return new(Api.CreateRenderBundle(Handle, descriptor));
    //    }
    //}

    public RenderPipeline CreateRenderPipeline(in RenderPipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateRenderPipeline(Handle, descriptor));
        }
    }
    public void CreateRenderPipelineAsync(in RenderPipelineDescriptor descriptor, PfnCreateRenderPipelineAsyncCallback callback, nint userData)
    {
        unsafe
        {
            Api.DeviceCreateRenderPipelineAsync(Handle, descriptor, callback, (void*)userData);
        }
    }
    public ShaderModule CreateShaderModule(in ShaderModuleDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateShaderModule(Handle, descriptor));
        }
    }

    public SwapChain CreateSwapChain(in SwapChainDescriptor descriptor, Surface surface)
    {
        unsafe
        {
            return new(Api.DeviceCreateSwapChain(Handle, surface, descriptor));
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
            fixed (T* ptr = data)
                return Api.DevicePopErrorScope(Handle, callback, ptr);
        }
    }
    public void PushErrorScope<T>(ErrorFilter filter)
        where T : unmanaged
    {
        unsafe
        {
            Api.DevicePushErrorScope(Handle, filter);
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
