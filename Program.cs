using System;
using Silk.NET.DXGI;
using Silk.NET.Direct3D11;
using Silk.NET.Core.Native;
using Silk.NET.Windowing;
using Silk.NET.Maths;
using Silk.NET.Input;

namespace DXDebug
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IGame g = new DXGame();
            g.Run();
        }
   }
}