# SoftTouch3D

A C# game engine prototype heavily inspired from Stride.

## Main prototype ideas

### Asset system

The asset system is managed by a cli tool called `coffret`.
It works like the dotnet cli tool and can add assets and compile them.

```powershell
# add an asset
coffret add --image --file <path-to-image> --path <output-path-in-asset-folder>
# compile assets
coffret compile
```

### Serialization

Serialization is done using two libraries

* VYaml for Yaml serialization
* MemoryPack for Binary serialization

Both those libraries are very fast and have low memory footprint.

### Graphics

Rendering done with WGPU with wgsl, might be replaced by Silk.NET.WebGpu. In the future, it will use SDSL (Stride shader language).

### ECS

A simple data-driven Entity-Component-System implementation.

It uses any structs as components, stores everything contiguously as much as possible and the query API has a very low memory footprint while allowing great performance.

In the future, a scheduler will be implemented for async-await and better parallelization of systems.
