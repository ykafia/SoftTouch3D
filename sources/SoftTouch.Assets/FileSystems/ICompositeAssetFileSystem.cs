using Zio;

namespace SoftTouch.Assets.FileSystems;
public interface ICompositeAssetFileSystem : IFileSystem
{
    string[] Extensions {get;}
    UPath SubPath {get;}
}

public interface ICompositeAssetFileSystem<Mesh,Image,Material> : ICompositeAssetFileSystem
{
    public Mesh GetMesh(UPath path);
    public Material GetMaterial(UPath path);
    public Image GetImage(UPath path);
}
