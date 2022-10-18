using WGPU.NET;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SoftTouch.Rendering;


public class ResourceAllocator
{
    Device device;
    ConcurrentDictionary<string,Texture> resources;


    public ResourceAllocator(Device d)
    {
        device = d;
        resources = new();
    }

    public void AllocateTexture(in Wgpu.TextureDescriptor descriptor)
    {
        var texture = device.CreateTexture(descriptor);
    }
}