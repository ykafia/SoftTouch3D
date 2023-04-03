using MemoryPack;
using Silk.NET.Vulkan;
using SoftTouch.Assets.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets;

public partial class ContentManager
{
    static ContentManager? instance;

    public static ContentManager GetInstance(AggregateFileSystem? f = null, Dictionary<UPath,UPath>? indirection = null)
    {
        if (instance is null)
            if (f is not null && indirection is not null)
                instance = new(f, indirection);
            else
                throw new Exception("Can't get instance without providing file system and indirection");
        return instance;
    }


    public AggregateFileSystem FileSystem { get; set; }
    public Dictionary<UPath, UPath> ContentIndexMap { get; set; }

    readonly Dictionary<UPath, object> loadedContent = new();

    Dictionary<Type, ContentLoader> Loaders = new();

    ContentManager(AggregateFileSystem fileSystem, Dictionary<UPath,UPath> indirection)
    {
        FileSystem = fileSystem;
        ContentIndexMap = indirection;
    }

    public void AddLoader<T>(ContentLoader<T> loader)
    {
        Loaders.Add(typeof(T), loader);
    }


    public T Load<T> (UPath path)
    {
        if(loadedContent.TryGetValue(path,out var result))
            return (T)result;
        else
        {
            if(Loaders.TryGetValue(typeof(T),out var loader))
            {
                loader.Load(path);
            }
            if (loadedContent.TryGetValue(path, out var asset))
                return (T)asset;
            else throw new Exception($"Cannot load type {typeof(T).Name}");
        }
    }
}
