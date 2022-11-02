using WGPU.NET;

namespace SoftTouch.Rendering;


public abstract class Sink
{
    public string Name {get;set;}
    public string PassName {get;set;}
    public string OutputName {get;set;}

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
    public Texture Texture {get;set;}

    public override void Bind(Source s)
    {
        throw new System.NotImplementedException();
    }

    public override void PostLinkValidate()
    {
        throw new System.NotImplementedException();
    }
}