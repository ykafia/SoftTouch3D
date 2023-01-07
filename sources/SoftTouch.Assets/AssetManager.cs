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
    public AssetsFileSystem AssetsFileSystem { get; private set; } = new();
    public readonly SortedList<string, AssetImporter> AssetImporters = new();
    public readonly Dictionary<UPath, AssetItem> LoadedAssets = new();

    public AssetManager(string resourcePath, WGPUGraphics gfx)
    {
        Gfx = gfx;
        var sub = new SubFileSystem(physicalFileSystem, physicalFileSystem.ConvertPathFromInternal(resourcePath));
        FileSystem.AddFileSystem(sub);
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