using System.Collections.Generic;
using System.Collections.Concurrent;
using SoftTouch.Graphics.SilkWrappers;

namespace SoftTouch.Rendering;


public class ResourceAllocator
{
    Device device;
    SortedList<string,Texture> Textures = new();
    ConcurrentDictionary<string,IGraphicResource> Resources;

    public ResourceAllocator(Device d)
    {
        device = d;
        Resources = new();
    }

    public void AllocateTexture(in Silk.NET.WebGPU.TextureDescriptor descriptor)
    {
        // Textures[descriptor.label] = device.CreateTexture(descriptor);
    }
    public void CreateTextureView(string textureName, in Silk.NET.WebGPU.TextureViewDescriptor descriptor)
    {
        // Resources[descriptor.label] = new TrasientTextureView(device, Textures[textureName].CreateTextureView(descriptor));
    }
    public void CreateBuffer(string textureName, in Silk.NET.WebGPU.BufferDescriptor descriptor)
    {
        // Resources[descriptor.label] = new TrasientBuffer(device, device.CreateBuffer(descriptor));
    }
    public void CreateSwapView(SwapChain swap)
    {
        // Resources["currentSwapView"] = new SwapChainView(device, swap);
    }
}