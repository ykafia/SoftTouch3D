using System;
using System.IO;
using System.Linq;
using ECSharp;
using System.Collections.Generic;
using SPIRVCross;
using static SPIRVCross.SPIRV;
using SoftTouch.Graphics.WGPU;
using SharpGLTF.Schema2;
using SoftTouch.Rendering;
using SoftTouch.Assets;
using Zio.FileSystems;

namespace SoftTouch
{

    public class Program
    {
        static string path = "../../assets/models/fox.glb";
        public static void Main(string[] _)
        {
            // var fs = new PhysicalFileSystem();
            // var am = new AssetManager(fs);
            // am.Load<Model>(path);
            // var model = am.Get(path);
            // var x = 0;
            IGame g = new Game();
            g.Run();
        }
    }
}