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
using SpanJson;
using Silk.NET.Maths;
using SpanJson.Resolvers;
using Zio;
using MemoryPack;
using SoftTouch.Assets.Serialization.MemoryPack;

MemoryPackFormatterProvider.Register(new UPathFormatter());

Console.WriteLine("Hello, world!");
var fs = new PhysicalFileSystem();
var sub = new SubFileSystem(fs, fs.ConvertPathFromInternal("./"));
sub.WriteAllText("/vec2.json", JsonSerializer.Generic.Utf16.Serialize(new Vector2D<float>(2,5)));

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

// MessagePackSerializer.DefaultOptions = SoftTouchResolver.Options;
// // Console.WriteLine(MessagePackSerializer.SerializeToJson(new PackaginConfig("/Resources/","/Assets/","/Shaders/")));
// var json = MessagePackSerializer.ConvertToJson(MessagePackSerializer.Serialize(new ModelAsset("/assets/models/Fox.glb")));
// Console.WriteLine(json);

// var g = new MyGame();
// g.Run();
