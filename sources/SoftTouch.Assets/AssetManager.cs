using System.Collections.Generic;
using System.IO;
using SoftTouch.Assets.FileSystems;
using SoftTouch.Assets.Importers;
using SoftTouch.Core.Assets;
using SoftTouch.Graphics;
using SoftTouch.Graphics.WGPU;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets;

public partial class AssetManager
{

    static AssetManager manager;

    public static AssetManager GetOrCreate(params string[] resourcePaths)
    {
        if(manager is null && resourcePaths.Length == 0)
            throw new ArgumentException($"Cannot create an asset manager without at least one folder");
        return manager ??= new AssetManager(resourcePaths);
    }

    GraphicsState Gfx => GraphicsState.GetOrCreate();
    static readonly PhysicalFileSystem physicalFileSystem = new();
    public ResourcesFileSystem FileSystem { get; private set; } = new();
    public AssetsFileSystem AssetsFileSystem { get; private set; } = new();
    public readonly SortedList<string, AssetImporter> AssetImporters = new();
    public readonly Dictionary<UPath, IAssetItem> LoadedAssets = new();

    AssetManager(params string[] resourcePaths)
    {
        foreach(var path in resourcePaths)
            FileSystem.AddFileSystem(
                new SubFileSystem(physicalFileSystem, physicalFileSystem.ConvertPathFromInternal(path))
            );
        // RegisterCAFS(static (fs,p) => new GltfAssetReader(fs,p),GltfAssetReader.Extensions);
    }

    public void RegisterCAFS<T>(Func<IFileSystem,UPath,T> creator, params string[] extensions)
        where T : GltfAssetReader
    {
        // foreach(var e in extensions)
        // foreach(var fs in FileSystem.GetFileSystems())
        // foreach(var p in fs.EnumeratePaths("/",$"*{e}",SearchOption.AllDirectories,SearchTarget.File))
        //     FileSystem.AddFileSystem(creator(fs,p));
    }

    
    public void AddImporter<T>()
        where T : AssetImporter, new()
    {
        var importer = new T();
        foreach(var ext in importer.Extensions)
            AssetImporters.Add(ext, importer);
    }
    public void RemoveImporter<T>()
        where T : AssetImporter
    {
        foreach (var item in AssetImporters.Where(kvp => kvp.Value is T))
        {
            AssetImporters.Remove(item.Key);
        }
    }
    public AssetImporter? GetImporter<T>()
        where T : AssetImporter
    {
        return AssetImporters.Values.FirstOrDefault(x => x is T);
    }
}