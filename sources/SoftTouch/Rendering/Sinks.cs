using WGPU.NET;

namespace SoftTouch.Rendering;


public abstract class Sink
{
    public required string Name {get;set;}
    public required string PassName {get;set;}
    public string? OutputName {get;set;}

    public abstract void PostLinkValidate();
    public abstract void Bind(Source s);
}

public sealed class DirectBufferSink : Sink
{
    public Buffer Buffer {get;set;}

    public override void Bind(Source s)
    {
        if(s is DirectBufferSource b)
            Buffer = b.Buffer;
        else
            throw new System.Exception("Not the correct resource type");
    }

    public override void PostLinkValidate()
    {
        throw new System.NotImplementedException();
    }
}
public sealed class DirectTextureSink : Sink
{
    public Texture? Texture {get;set;}
    public Sampler? TextureSampler {get;set;}

    public override void Bind(Source s)
    {
        if(s is DirectTextureSource dts)
        {
            Texture = dts.Texture;
            TextureSampler = dts.TextureSampler;
        }
        else throw new System.Exception("Source doesn't contain a texture");
    }

    public override void PostLinkValidate()
    {
        throw new System.NotImplementedException();
    }
}