using WGPU.NET;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SoftTouch.Rendering;


public class ResourceAllocator
{
    Device device;
    ConcurrentDictionary<string,Texture> textures;


    public ResourceAllocator(Device d)
    {
        device = d;
        textures = new();
    }

    public void AllocateTexture(in Wgpu.TextureDescriptor descriptor)
    {
        textures.GetOrAdd(descriptor.label, device.CreateTexture(descriptor));
    }
}