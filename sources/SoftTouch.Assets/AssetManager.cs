using System.Collections.Generic;
using System.IO;
using SoftTouch.Assets.FileSystems;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets;

public class AssetManager
{
    PhysicalFileSystem physicalFileSystem = new();
    
    AggregateFileSystem fileSystem = new();

    Dictionary<UPath, IAsset> LoadedAssets = new();

    public AssetManager()
    {
        var sub = new SubFileSystem(physicalFileSystem, physicalFileSystem.ConvertPathFromInternal("../../assets/"));
        fileSystem.AddFileSystem(sub);
        sub.EnumerateFiles("/","*.glb",SearchOption.AllDirectories).ToList().ForEach(x => AddFileSystem(new GltfFileSystem(sub,x.FullName)));
        fileSystem.EnumerateItems("/",SearchOption.AllDirectories).ToList().ForEach(x => Console.WriteLine(x));
    }

    public void AddFileSystem(params IFileSystem[] fileSystems)
    {
        foreach(var fs in fileSystems)
            fileSystem.AddFileSystem(fs);
    }

    public IAsset<T> Load<T>(string path) 
        where T : IAsset<T>
    {
        if(LoadedAssets.TryGetValue(path, out var res))
            return (IAsset<T>)res;
        else
        {
            var asset = T.Load(path,fileSystem);
            // if(asset is IComposableAsset<T> ca)
            // {
            //     foreach(var e in ca)
            //         LoadedAssets.Load(path)
            // }
            LoadedAssets.Add(path,asset);
            return (IAsset<T>)LoadedAssets[path];
        }
    }

    public void Unload(string path)
    {
        LoadedAssets[path].Unload();
        LoadedAssets.Remove(path);
    }
}