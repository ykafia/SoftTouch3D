using System;
using System.Linq;
using SoftTouch.Assets;
using SoftTouch.Graphics.WebGPU;
using System.IO;

// var fs = new PhysicalFileSystem();
// var sub = new SubFileSystem(fs,fs.ConvertPathFromInternal("../../assets/"));
// var gltf = new GltfFileSystem(fs, fs.ConvertPathFromInternal("../../assets/models/Fox.glb"));

// foreach( var e in gltf.EnumerateItems("/", System.IO.SearchOption.TopDirectoryOnly))
//     Console.WriteLine(e);

var manager = new AssetManager("../../assets/",new WGPUGraphics());
manager.FileSystem
    .EnumerateItems("/",SearchOption.AllDirectories)
    .ToList()
    .ForEach(x => Console.WriteLine(x));
// var g = new MyGame();
// g.Run();
