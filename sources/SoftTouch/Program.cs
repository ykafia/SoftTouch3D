using System;
using SoftTouch;
using SoftTouch.Assets;
using Zio;
using Zio.FileSystems;
using System.Linq;
using SoftTouch.Assets.FileSystems;

var pfs = new PhysicalFileSystem();

var subfs = pfs.GetOrCreateSubFileSystem(
    pfs.ConvertPathFromInternal(@"C:\Users\youness_kafia\Documents\dotnetProjs\SoftTouch3D\assets")
);
foreach(var e in subfs.EnumeratePaths("/","*.glb",System.IO.SearchOption.AllDirectories,SearchTarget.File))
{
    var g = new GltfFileSystem(subfs,e);
    var image = g.GetImage("/models/Fox.glb/images/0");
}

// var game = new MyGame();
// game.Run();