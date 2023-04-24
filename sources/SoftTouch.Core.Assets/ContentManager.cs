using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;
using Zio.FileSystems;

namespace SoftTouch.Core.Assets;

public class ContentManager
{
    static ContentManager instance = null!;

    public static ContentManager GetOrCreate(UPath? path = null)
    {
        if (instance is not null)
            return instance;
        instance = new ContentManager(path ?? UPath.Empty);
        return instance;
    }

    static PhysicalFileSystem pfs = new();

    static Dictionary<Type, ContentSerializer> Serializers = new();


    public SubFileSystem SubFileSystem { get; init; }

    ContentManager(UPath path)
    {
        if (path.IsEmpty)
            SubFileSystem = new(pfs, pfs.ConvertPathFromInternal(Directory.GetCurrentDirectory()));
        SubFileSystem = new(pfs, path);
    }

    public Stream OpenFile(UPath path, FileMode mode, FileAccess access)
    {
        return SubFileSystem.OpenFile(path, mode, access);
    }
    public Stream ReadFile(UPath path)
    {
        return OpenFile(path, FileMode.Open, FileAccess.Read);
    }

    public MemoryStream ReadFileAsMemory(UPath path)
    {
        using var stream = OpenFile(path, FileMode.Open, FileAccess.Read);
        var memory = new MemoryStream();
        stream.CopyTo(memory);
        return memory;
    }

    public void Deserialize<T>(UPath path, out T data)
    {
        using var stream = ReadFileAsMemory(path);
        data = MemoryPackSerializer.Deserialize<T>(stream.ToArray()) ?? throw new Exception("Could not deserialize data, data is null");
    }


    public static void Register<T>(ContentSerializer<T> serializer)
    {
        Serializers.Add(typeof(T), serializer);
    }

    public static T Load<T>(UPath path)
    {
        return ((ContentSerializer<T>)Serializers[typeof(T)]).Load(path);
    }
    public static void Save<T>(UPath path)
    {
        throw new NotImplementedException();
        //ContentManager.GetOrCreate().OpenFile(path, FileMode.Open, FileAccess.Read);
    }

}
