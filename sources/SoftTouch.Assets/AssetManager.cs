using System.Collections.Generic;
using System.IO;
using Zio;

namespace SoftTouch.Assets;

public class AssetManager
{
    IFileSystem fileSystem;

    Dictionary<UPath, IAsset> LoadedAssets = new();

    public AssetManager(IFileSystem fs)
    {
        fileSystem = fs;
    }

    public IAsset<T> Load<T>(string path) 
        where T : IAsset<T>
    {
        if(LoadedAssets.TryGetValue(path, out var res))
            return (IAsset<T>)res;
        else
        {
            LoadedAssets.Add(path, T.Load(path,fileSystem));
            return (IAsset<T>)LoadedAssets[path];
        }
    }

    public void Unload(string path)
    {
        LoadedAssets[path].Unload();
        LoadedAssets.Remove(path);
    }
}