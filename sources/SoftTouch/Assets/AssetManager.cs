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

    public void Load<T>(string path) 
        where T : IAsset<T>
    {
        var upath = fileSystem.ConvertPathFromInternal(path);
        LoadedAssets[path] = T.Load(upath,fileSystem);
    } 
    public IAsset Get(string name)
    {
        return LoadedAssets[name];
    } 
}