using Silk.NET.SDL;
using Silk.NET.WebGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class Device : GraphicsBaseObject<Silk.NET.WebGPU.Device>
{
    internal unsafe Device(Silk.NET.WebGPU.Device* handle) : base(handle)
    {
    }

    public Buffer CreateBuffer(Silk.NET.WebGPU.BufferDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBuffer(Handle, &descriptor));
        }
    }
    public Texture CreateTexture(Silk.NET.WebGPU.TextureDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateTexture(Handle, &descriptor));
        }
    }
    public Sampler CreateSampler(Silk.NET.WebGPU.SamplerDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateSampler(Handle, &descriptor));
        }
    }
    public BindGroup CreateBindGroup(Silk.NET.WebGPU.BindGroupDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBindGroup(Handle, &descriptor));
        }
    }
    public BindGroupLayout CreateBindGroupLayout(Silk.NET.WebGPU.BindGroupLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateBindGroupLayout(Handle, &descriptor));
        }
    }
    public CommandEncoder CreateCommandEncoder(Silk.NET.WebGPU.CommandEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateCommandEncoder(Handle, &descriptor));
        }
    }
    public ComputePipeline CreateComputePipeline(Silk.NET.WebGPU.ComputePipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateComputePipeline(Handle, &descriptor));
        }
    }
    public QuerySet CreateQuerySet(Silk.NET.WebGPU.QuerySetDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateQuerySet(Handle, &descriptor));
        }
    }
    public void CreateComputePipelineAsync<T0>(Silk.NET.WebGPU.ComputePipelineDescriptor descriptor, Silk.NET.WebGPU.PfnCreateComputePipelineAsyncCallback callback, ref T0 userData)
        where T0 : unmanaged
    {
        unsafe
        {
            Api.DeviceCreateComputePipelineAsync(Handle, &descriptor, callback, ref userData);
        }
    }
    public PipelineLayout CreatePipelineLayout(Silk.NET.WebGPU.PipelineLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreatePipelineLayout(Handle, &descriptor));
        }
    }
    public RenderBundleEncoder CreateRenderBundleEncoder(Silk.NET.WebGPU.RenderBundleEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateRenderBundleEncoder(Handle, &descriptor));
        }
    }

    // TODO : This shouldn't exist per the doc : https://www.w3.org/TR/webgpu/
    //public RenderBundle CreateRenderBundle(Silk.NET.WebGPU.RenderBundleDescriptor descriptor)
    //{
    //    unsafe
    //    {
    //        return new(Api.CreateRenderBundle(Handle, &descriptor));
    //    }
    //}

    public RenderPipeline CreateRenderPipeline(Silk.NET.WebGPU.RenderPipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateRenderPipeline(Handle, &descriptor));
        }
    }
    public void CreateRenderPipelineAsync(Silk.NET.WebGPU.RenderPipelineDescriptor descriptor, Silk.NET.WebGPU.PfnCreateRenderPipelineAsyncCallback callback, nint userData)
    {
        unsafe
        {
            Api.DeviceCreateRenderPipelineAsync(Handle, &descriptor, callback, (void*)userData);
        }
    }
    public ShaderModule CreateShaderModule(Silk.NET.WebGPU.ShaderModuleDescriptor descriptor)
    {
        unsafe
        {
            return new(Api.DeviceCreateShaderModule(Handle, &descriptor));
        }
    }

    public SwapChain CreateSwapChain(Silk.NET.WebGPU.SwapChainDescriptor descriptor, Surface surface)
    {
        unsafe
        {
            return new(Api.DeviceCreateSwapChain(Handle, surface.Handle, &descriptor));
        }
    }

    public object Queue {get { unsafe { return new(Api.DeviceGetQueue(Handle)); } }


    public override void Dispose()
    {
       
        unsafe
        {
            Graphics.Disposal.Dispose(Handle);
        }
    }
}
