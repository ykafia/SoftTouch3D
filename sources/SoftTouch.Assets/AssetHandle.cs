using MemoryPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zio;

namespace SoftTouch.Assets;

public struct AssetHandle<T>
{
    [MemoryPackIgnore]
    public T Item => ContentManager.GetInstance().Load<T>(ItemPath);

    [MemoryPackInclude]
    public UPath ItemPath { get; set; }

    public AssetHandle(UPath path)
    {
        ItemPath = path;
    }
}
