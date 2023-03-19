using System.Collections.Generic;
using SoftTouch.Graphics.WGPU;
using Buffer = SoftTouch.Graphics.WGPU.Buffer;

namespace SoftTouch.Rendering;

public abstract class BindingPass : RenderPass
{
    List<Silk.NET.WebGPU.BindGroupEntry> bindGroupEntries = new();
    List<Silk.NET.WebGPU.BindGroupLayoutEntry> bindGroupLayouts = new();
    protected BindingPass(string name) : base(name){}

    public void AddBindGroupLayout(uint binding, Silk.NET.WebGPU.TextureBindingLayout layout, Silk.NET.WebGPU.TextureView view)
    {
        // bindGroupLayouts.Add(
        //     new(){
        //         Binding = binding,
        //         Texture = layout,
        //     }
        // );
        // unsafe
        // {
        //     bindGroupEntries.Add(
        //         new BindGroupEntry{
        //             Binding = binding,
        //             TextureView = &view
        //         }
        //     );
        // }
    }
    public void AddBindGroupLayout(uint binding, Silk.NET.WebGPU.BufferBindingLayout layout, Buffer buffer)
    {
        // bindGroupLayouts.Add(
        //     new(){
        //         binding = binding,
        //         buffer = layout
        //     }
        // );
        // bindGroupEntries.Add(
        //     new BindGroupEntry{
        //         Binding = binding,
        //         Buffer = buffer
        //     }
        // );
    }
    public void AddBindGroupLayout(uint binding, Silk.NET.WebGPU.SamplerBindingLayout layout, Sampler sampler)
    {
        // bindGroupLayouts.Add(
        //     new(){
        //         binding = binding,
        //         sampler = layout
        //     }
        // );
        // bindGroupEntries.Add(
        //     new BindGroupEntry{
        //         Binding = binding,
        //         Sampler = sampler
        //     }
        // );
    }
}