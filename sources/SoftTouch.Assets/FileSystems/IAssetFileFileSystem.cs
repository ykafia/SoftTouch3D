using Zio;

namespace SoftTouch.Assets.FileSystems;
public interface ICompositeAssetFileSystem : IFileSystem
{
    string[] Extensions {get;}
    UPath SubPath {get;}
}
