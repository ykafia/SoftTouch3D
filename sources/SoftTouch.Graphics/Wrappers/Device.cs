using Silk.NET.SDL;
using Silk.NET.WebGPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Graphics.SilkWrappers;

public class Device
{
    Silk.NET.WebGPU.WebGPU api => SilkGraphicsState.GetOrCreate().Api;

    readonly unsafe Silk.NET.WebGPU.Device* device;

    public Buffer CreateBuffer(Silk.NET.WebGPU.BufferDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateBuffer(device, &descriptor));
        }
    }
    public Texture CreateTexture(Silk.NET.WebGPU.TextureDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateTexture(device, &descriptor));
        }
    }
    public Sampler CreateSampler(Silk.NET.WebGPU.SamplerDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateSampler(device, &descriptor));
        }
    }
    public BindGroup CreateBindGroup(Silk.NET.WebGPU.BindGroupDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateBindGroup(device, &descriptor));
        }
    }
    public BindGroupLayout CreateBindGroupLayout(Silk.NET.WebGPU.BindGroupLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateBindGroupLayout(device, &descriptor));
        }
    }
    public CommandEncoder CreateCommandEncoder(Silk.NET.WebGPU.CommandEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateCommandEncoder(device, &descriptor));
        }
    }
    public ComputePipeline CreateComputePipeline(Silk.NET.WebGPU.ComputePipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateComputePipeline(device, &descriptor));
        }
    }
    public QuerySet CreateQuerySet(Silk.NET.WebGPU.QuerySetDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateQuerySet(device, &descriptor));
        }
    }
    public void CreateComputePipelineAsync<T0>(Silk.NET.WebGPU.ComputePipelineDescriptor descriptor, Silk.NET.WebGPU.PfnCreateComputePipelineAsyncCallback callback, ref T0 userData)
        where T0 : unmanaged
    {
        unsafe
        {
            api.DeviceCreateComputePipelineAsync(device, &descriptor, callback, ref userData);
        }
    }
    public PipelineLayout CreatePipelineLayout(Silk.NET.WebGPU.PipelineLayoutDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreatePipelineLayout(device, &descriptor));
        }
    }
    public RenderBundleEncoder CreateRenderBundleEncoder(Silk.NET.WebGPU.RenderBundleEncoderDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateRenderBundleEncoder(device, &descriptor));
        }
    }

    // TODO : check that
    //public RenderBundle CreateRenderBundle(Silk.NET.WebGPU.RenderBundleDescriptor descriptor)
    //{
    //    unsafe
    //    {
    //        return new(api.CreateRenderBundle(device, &descriptor));
    //    }
    //}

    public RenderPipeline CreateRenderPipeline(Silk.NET.WebGPU.RenderPipelineDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateRenderPipeline(device, &descriptor));
        }
    }
    public void CreateRenderPipelineAsync(Silk.NET.WebGPU.RenderPipelineDescriptor descriptor, Silk.NET.WebGPU.PfnCreateRenderPipelineAsyncCallback callback, nint userData)
    {
        unsafe
        {
            api.DeviceCreateRenderPipelineAsync(device, &descriptor, callback, (void*)userData);
        }
    }
    public ShaderModule CreateShaderModule(Silk.NET.WebGPU.ShaderModuleDescriptor descriptor)
    {
        unsafe
        {
            return new(api.DeviceCreateShaderModule(device, &descriptor));
        }
    }
    //public SwapChain CreateSwapChain(Silk.NET.WebGPU.SwapChainDescriptor descriptor, Silk.NET.WebGPU.Surface surface)
    //{
    //    unsafe
    //    {
    //      return new(api.DeviceCreateSwapChain(device, &descriptor, surface.Handle));
    //    }
    //}
}
