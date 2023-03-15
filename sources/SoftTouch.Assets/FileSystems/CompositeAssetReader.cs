using Zio;

namespace SoftTouch.Assets.FileSystems;




public abstract class CompositeAssetReader
{
    public abstract string[] Extensions {get;}
    public UPath FilePath { get; init; }
    
    protected CompositeAssetReader(IFileSystem fs, UPath filePath)
    {
    }

    public abstract object? GetMesh(string name);
    public abstract object? GetMaterial(string name);
    public abstract object? GetImage(string name);
}
