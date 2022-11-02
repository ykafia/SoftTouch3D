using System.Numerics;
using WGPU.NET;
namespace SoftTouch.Rendering;

public interface IGraphicResource
{
    public Device Device { get; }
}

public interface ITransientResource : IGraphicResource
{
    void Dispose();
}

public interface IExternalResource : IGraphicResource { }


public struct BufferInfo
{
    public long Size = 0;
    public Wgpu.BufferUsage Usage = 0;
    public bool Persistent = true;

    public BufferInfo() { }
    public BufferInfo(long size, Wgpu.BufferUsage usage, bool persistent)
    {
        Size = size;
        Usage = usage;
        Persistent = persistent;
    }
}
public enum SizeClass
{
	Absolute,
	SwapchainRelative,
	InputRelative
};
public struct TextureInfo
{
    public SizeClass SizeClass {get;set;} = SizeClass.SwapchainRelative;
	public Vector2 Size {get;set;} = Vector2.One;
	public Wgpu.TextureFormat Format {get;set;} = Wgpu.TextureFormat.Undefined;
	public string? SizeRelativeName {get;set;} = null;
	public uint Samples {get;set;} = 1;
	public uint Levels {get;set;} = 1;
	public uint Layers {get;set;} = 1;
	public bool Persistent {get;set;} = true;

    public TextureInfo(){}
}