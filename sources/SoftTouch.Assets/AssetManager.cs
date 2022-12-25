using System.Collections.Generic;
using System.IO;
using SoftTouch.Assets.FileSystems;
using SoftTouch.Assets.Importers;
using SoftTouch.Graphics.WebGPU;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets;

public partial class AssetManager
{
    WGPUGraphics Gfx;
    readonly PhysicalFileSystem physicalFileSystem = new();
    public ResourcesFileSystem FileSystem { get; private set; } = new();
    public readonly Dictionary<Type, AssetImporter> AssetImporters = new();
    public readonly Dictionary<UPath, IAsset> LoadedAssets = new();

    public AssetManager(string resourcePath, WGPUGraphics gfx)
    {
        Gfx = gfx;
        var sub = new SubFileSystem(physicalFileSystem, physicalFileSystem.ConvertPathFromInternal(resourcePath));
        FileSystem.AddFileSystem(sub);
        sub.EnumerateFiles("/", "*.glb", SearchOption.AllDirectories).ToList().ForEach(x => AddFileSystem(new GltfFileSystem(sub, x.FullName)));
        sub.EnumerateFiles("/", "*.gltf", SearchOption.AllDirectories).ToList().ForEach(x => AddFileSystem(new GltfFileSystem(sub, x.FullName)));
        AddImporter<Importers.GLTF.GLTFModelImporter>();
        var importer = GetImporter<Importers.GLTF.GLTFModelImporter>();
        var asset = importer.Import("/models/Fox.glb/meshes/fox1", this);
    }

    public void AddFileSystem(params IFileSystem[] fileSystems)
    {
        foreach (var fs in fileSystems)
            FileSystem.AddFileSystem(fs);
    }
    public void AddImporter<T>()
        where T : AssetImporter, new()
    {
        AssetImporters.Add(typeof(T), new T());
    }
    public void RemoveImporter<T>()
        where T : AssetImporter
    {
        AssetImporters.Remove(typeof(T));
    }
    public AssetImporter GetImporter<T>()
        where T : AssetImporter
    {
        return AssetImporters[typeof(T)];
    }

    public T Load<T>(string path)
        where T : IAsset
    {
        if (LoadedAssets.TryGetValue(path, out var res))
            return (T)res;
        else
        {
            var asset = AssetImporters[typeof(T)].Import(path, this);
            // if(asset is IComposableAsset<T> ca)
            // {
            //     foreach(var e in ca)
            //         LoadedAssets.Load(path)
            // }
            LoadedAssets.Add(path, asset);
            return (T)LoadedAssets[path];
        }
    }

    public void Unload(string path)
    {
        LoadedAssets[path].Unload();
        LoadedAssets.Remove(path);
    }
}