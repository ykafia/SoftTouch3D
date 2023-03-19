using SoftTouch.Graphics.WGPU;
using Buffer = SoftTouch.Graphics.WGPU.Buffer;

namespace SoftTouch.Rendering;

public abstract class Source
{
    public string Name {get;set;}

}

public class DirectBufferSource : Source
{
    public Buffer Buffer {get;set;}
}
public class DirectTextureSource : Source
{
    public Texture? Texture {get;set;}
    public Sampler? TextureSampler {get;set;}
}