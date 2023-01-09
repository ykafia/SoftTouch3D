using MemoryPack;
using Silk.NET.Vulkan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Assets;

public class ContentLoader
{
    static ContentLoader? Instance;

    public static ContentLoader GetInstance(AggregateFileSystem? f = null, Dictionary<UPath,UPath>? indirection = null)
    {
        if (Instance is null)
            if (f is not null && indirection is not null)
                Instance = new(f, indirection);
            else
                throw new Exception("Can't get instance without providing file system and indirection");
        return Instance;
    }

    public AggregateFileSystem FileSystem { get; set; }
    public Dictionary<UPath, UPath> Indirection { get; set; }

    readonly Dictionary<UPath, object> loadedContent = new();

    ContentLoader(AggregateFileSystem fileSystem, Dictionary<UPath,UPath> indirection)
    {
        FileSystem = fileSystem;
        Indirection = indirection;
    }

    public T Load<T> (UPath path)
    {
        if(loadedContent.TryGetValue(path,out var result))
            return (T)result;
        else
        {
            var loaded = MemoryPackSerializer.Deserialize<T>(FileSystem.ReadAllBytes(path));
            if (loaded is null)
                throw new Exception("Loaded asset is null");
            loadedContent.Add(path, loaded);
            return loaded;
        }
    }



}
