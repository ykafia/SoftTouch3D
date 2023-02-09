using System.Collections.Generic;
using WGPU.NET;
using Buffer = WGPU.NET.Buffer;

namespace SoftTouch.Rendering;

public abstract class BindingPass : RenderPass
{
    List<BindGroupEntry> bindGroupEntries = new();
    List<Wgpu.BindGroupLayoutEntry> bindGroupLayouts = new();
    protected BindingPass(string name) : base(name){}

    public void AddBindGroupLayout(uint binding,Wgpu.TextureBindingLayout layout, TextureView view)
    {
        bindGroupLayouts.Add(
            new(){
                binding = binding,
                texture = layout,
            }
        );
        bindGroupEntries.Add(
            new BindGroupEntry{
                Binding = binding,
                TextureView = view
            }
        );
    }
    public void AddBindGroupLayout(uint binding,Wgpu.BufferBindingLayout layout, Buffer buffer)
    {
        bindGroupLayouts.Add(
            new(){
                binding = binding,
                buffer = layout
            }
        );
        bindGroupEntries.Add(
            new BindGroupEntry{
                Binding = binding,
                Buffer = buffer
            }
        );
    }
    public void AddBindGroupLayout(uint binding,Wgpu.SamplerBindingLayout layout, Sampler sampler)
    {
        bindGroupLayouts.Add(
            new(){
                binding = binding,
                sampler = layout
            }
        );
        bindGroupEntries.Add(
            new BindGroupEntry{
                Binding = binding,
                Sampler = sampler
            }
        );
    }
}