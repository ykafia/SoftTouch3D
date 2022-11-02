using System.Collections.Generic;
using System.IO;
using Zio;

namespace SoftTouch.Assets;




public class AssetManager
{
    IFileSystem fileSystem;

    Dictionary<string, IAsset> LoadedAssets = new();

    public AssetManager(IFileSystem fs)
    {
        fileSystem = fs;
    }

    public void Load<T>(string path) 
        where T : IAsset
    {
        T.Load(path,fileSystem.OpenFile(path, FileMode.Open, FileAccess.Read));
    }

    struct AssetID
    {
        public readonly string Path;
        public readonly string Name;
    }
}