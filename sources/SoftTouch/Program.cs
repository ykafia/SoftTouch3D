using System;
using SoftTouch;
using SoftTouch.Assets;
using Zio;
using Zio.FileSystems;
using System.Linq;
using SoftTouch.Assets.FileSystems;

var myPath = @"C:\Users\youness_kafia\Documents\dotnetProjs\SoftTouch3D\assets";

var pfs = new PhysicalFileSystem();

var aman = AssetManager.GetOrCreate(myPath);
aman.RegisterCAFS((fs,p) => new GltfFileSystem(fs,p),GltfFileSystem.Extensions);
var x = 0;
// var game = new MyGame();
// game.Run();