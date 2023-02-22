using WGPU.NET;
using static WGPU.NET.Wgpu;

namespace SoftTouch.Graphics.Core;

public interface IGraphics
{
    public static abstract IGraphics GetInstance();
    public WGPU.NET.Buffer CreateBuffer(string label, bool mappedAtCreation, ulong size, BufferUsage usage);
    public Sampler CreateSampler(
        string label,
        AddressMode addressModeU,
        AddressMode addressModeV,
        AddressMode addressModeW,
        FilterMode magFilter,
        FilterMode minFilter,
        MipmapFilterMode mipmapFilter,
        float lodMinClamp,
        float lodMaxClamp,
        CompareFunction compare,
        ushort maxAnisotropy
    );
    public Texture CreateTexture(
        string label, 
        TextureUsage usage,
        TextureDimension dimension, 
        Extent3D size, 
        TextureFormat format,
        uint mipLevelCount, 
        uint sampleCount
    );
    public ShaderModule CreateWgslShaderModule(string label, string wgslCode);
    public ShaderModule CreateSpirvShaderModule(string label, byte[] spirvCode);

    
}