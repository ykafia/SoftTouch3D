using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Assets;

public class AssetHandle<T>
{
    
    [MemoryPackIgnore]
    public T Item { get; set; }

    [MemoryPackInclude]
    public UPath ItemPath { get; set; }

    public AssetHandle(UPath path)
    {
        ItemPath = path;
        Item = ContentLoader.GetInstance().Load<T>(path);
    }
}
