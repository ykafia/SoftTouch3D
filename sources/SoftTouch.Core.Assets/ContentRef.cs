using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Core.Assets;

[MemoryPackable]
public partial class ContentRef<TContent>
{
    public string AssetPath { get; init; }
    [MemoryPackIgnore]
    public TContent Item => ContentManager.Load<TContent>(AssetPath);

    public ContentRef(string assetPath)
    {
        AssetPath = assetPath;
    }
}
