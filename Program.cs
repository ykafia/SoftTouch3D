using System;
using System.Linq;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;
using WonkECS;
using WonkECS.Components;
using System.Collections.Generic;

namespace DXDebug
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IGame g = new OGLGame();
            g.Run();            
        }
   }
}