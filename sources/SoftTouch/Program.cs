using System;
using System.Linq;
using SoftTouch.Assets;
using SoftTouch.Graphics.WebGPU;
using System.IO;
using Zio.FileSystems;
using System.Collections.Generic;
// using SoftTouch.Assets.Serialization.Yaml;
using MessagePack;
using MessagePack.Resolvers;
using SoftTouch;
using Utf8Json;
using Silk.NET.Maths;
using Utf8Json.Resolvers;
using Zio;
using MemoryPack;
using SoftTouch.Assets.Serialization.MemoryPack;

MemoryPackFormatterProvider.Register(new UPathFormatter());

Console.WriteLine("Hello, world!");
var fs = new PhysicalFileSystem();
var sub = new SubFileSystem(fs, fs.ConvertPathFromInternal("./"));
//var packageConfig = new PackageConfig(
//    "1.0.0", 
//    new(
//        "Resources", 
//        "Assets", 
//        "Shaders"
//    )
//);
//var serialized = JsonSerializer.Serialize(packageConfig);
//Console.WriteLine(serialized);
//sub.WriteAllBytes("/SoftTouch.stpkg", serialized);

// var fs = new PhysicalFileSystem();
// var sub = new SubFileSystem(fs,fs.ConvertPathFromInternal("../../assets/"));
// var gltf = new GltfFileSystem(fs, fs.ConvertPathFromInternal("../../assets/models/Fox.glb"));

// foreach( var e in gltf.EnumerateItems("/", System.IO.SearchOption.TopDirectoryOnly))
//     Console.WriteLine(e);

// var manager = new AssetManager("../../assets/",new WGPUGraphics());
// manager.FileSystem
//     .EnumerateItems("/",SearchOption.AllDirectories)
//     .ToList()
//     .ForEach(x => Console.WriteLine(x));



// var g = new MyGame();
// g.Run();
