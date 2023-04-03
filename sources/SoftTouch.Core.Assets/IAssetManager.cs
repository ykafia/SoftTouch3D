using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio.FileSystems;
using Zio;

namespace SoftTouch.Core.Assets;


public class AssetManager
{

    static AssetManager manager;

    public static AssetManager GetOrCreate(params string[] resourcePaths)
    {
        if (manager is null && resourcePaths.Length == 0)
            throw new ArgumentException($"Cannot create an asset manager without at least one folder");
        return manager ??= new AssetManager(resourcePaths);
    }

    static readonly PhysicalFileSystem physicalFileSystem = new();
    public ResourceFileSystem FileSystem { get; private set; } = new();
    public AssetFileSystem AssetsFileSystem { get; private set; } = new();
    public Dictionary<string, IAssetImporter> AssetImporters { get; init; }

    public readonly Dictionary<UPath, IAssetItem> LoadedAssets = new();

    public AssetManager(params string[] resourcePaths)
    {
        AssetImporters = new();
        foreach (var path in resourcePaths)
            FileSystem.AddFileSystem(
                new SubFileSystem(physicalFileSystem, physicalFileSystem.ConvertPathFromInternal(path))
            );
    }

    public static void Register<T>() where T : IAssetImporter, new()
    {
        var importer = new T();
        foreach (var ext in importer.Extensions)
        {
            var manager = GetOrCreate();
            manager.AssetImporters.Add(ext, importer);
        }
    }
}
