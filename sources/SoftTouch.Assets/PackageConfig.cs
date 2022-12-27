using MemoryPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SoftTouch.Assets;

[MemoryPackable]
public sealed partial class PackageConfig
{
    [MemoryPackIgnore]
    [IgnoreDataMember]
    public string Extension { get; init; } = "pkg";

    [MemoryPackInclude]
    public string Version { get; set; }

    [MemoryPackInclude]
    public ProjectPaths Paths { get; set; }

    public PackageConfig() 
    {
        Version = "1.0.0";
        Paths = new();
    }


    [MemoryPackConstructor]
    public PackageConfig(string version, ProjectPaths paths) 
    {
        Version = version;
        Paths = paths;
    }

}
