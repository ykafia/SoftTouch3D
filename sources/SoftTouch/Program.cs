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

namespace SoftTouch
{

    public class Program
    {
        public static void Main(string[] _)
        {
            IGame g = new Game();
            g.Run();
        }
    }
}