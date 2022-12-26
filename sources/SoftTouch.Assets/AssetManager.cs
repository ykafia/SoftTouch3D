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
    public readonly Dictionary<Type, AssetImporter> AssetImporters = new();
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
}