using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets;

[MemoryPackable]
public sealed partial class PackageConfig
{
    [MemoryPackIgnore]
    public string Extension { get; init; } = "pkg";

    [MemoryPackInclude]
    public string Version { get; set; }

    [MemoryPackInclude]
    public ProjectPaths Paths { get; set; }

    [MemoryPackConstructor]
    public PackageConfig(string version, ProjectPaths paths) 
    {
        Version = version;
        Paths = paths;
    }

}
