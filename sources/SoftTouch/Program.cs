using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using MessagePack;
using MessagePack.Resolvers;
using Silk.NET.Maths;
using SoftTouch.Assets;
using SoftTouch.Components;
using SoftTouch.Games;
using Zio.FileSystems;
using SoftTouch.Assets.FileSystems;

// var fs = new PhysicalFileSystem();
// var sub = new SubFileSystem(fs,fs.ConvertPathFromInternal("../../assets/"));
// var gltf = new GltfFileSystem(fs, fs.ConvertPathFromInternal("../../assets/models/Fox.glb"));

// foreach( var e in gltf.EnumerateItems("/", System.IO.SearchOption.TopDirectoryOnly))
//     Console.WriteLine(e);

var manager = new AssetManager();

// var g = new MyGame();
// g.Run();
